using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Windows.Forms;
using System.Threading;
using System.Drawing;
using System.Linq;
using System.IO;
using System;

namespace XNBUVExplorer
{
    public partial class MainForm : Form
    {
        #region Fields

        private Texture2D _texture;
        private Bitmap _bitmap;
        private ContentManager _content;

        private float ZoomScale => Zoom_TrackBar.Value / 1.0f;
        private readonly List<Rectangle> _detectedTiles = new List<Rectangle>();

        private readonly int CanvasMargin = 30;

        #endregion

        #region Constructor

        public MainForm()
        {
            InitializeComponent();

            // Hook repaint events.
            this.Resize += (s, e) => XnbView_Panel.Invalidate();
            TileU_NumericUpDown.ValueChanged += (s, e) => XnbView_Panel.Invalidate();
            TileV_NumericUpDown.ValueChanged += (s, e) => XnbView_Panel.Invalidate();
            Zoom_TrackBar.ValueChanged += (s, e) => XnbView_Panel.Invalidate();
            Zoom_TrackBar.ValueChanged += (s, e) =>
            {
                Zoom_Label.Text = $"Zoom: {ZoomScale * 100:F0}%";
                XnbView_Panel.Invalidate();
            };
            DynamicLabeling_CheckBox.CheckedChanged += (s, e) =>
            {
                XnbView_Panel.Invalidate();
                UOffset_NumericUpDown.Enabled = !DynamicLabeling_CheckBox.Checked;
                VOffset_NumericUpDown.Enabled = !DynamicLabeling_CheckBox.Checked;
                UpdateTileCount();
            };
            UOffset_NumericUpDown.ValueChanged += (s, e) => XnbView_Panel.Invalidate();
            VOffset_NumericUpDown.ValueChanged += (s, e) => XnbView_Panel.Invalidate();
            RefreshUI_Button.Click += (s, e) =>
            {
                XnbView_Panel.Invalidate();
                DetectTexturesAndFillGrid();
                FillTextureInfoGrid();
                UpdateTileCount();
            };
            ColumnSorting_RadioButton.CheckedChanged += (s, e) => { XnbView_Panel.Invalidate(); FillTextureInfoGrid(); };
            RowSorting_RadioButton.CheckedChanged += (s, e) => { XnbView_Panel.Invalidate(); FillTextureInfoGrid(); };
            CopyData_Button.Click += CopyGrid_Button_Click;

            // Update initial labels.
            Zoom_Label.Text = $"Zoom: {Zoom_TrackBar.Value * 100}%";

            TextureInfo_Grid.Columns.Clear();
            TextureInfo_Grid.Columns.Add("", "UV");
            TextureInfo_Grid.Columns.Add("", "Gap Above");
            TextureInfo_Grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            TextureInfo_Grid.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;

            // Give each column the same "FillWeight" so they split the space evenly.
            TextureInfo_Grid.Columns[0].FillWeight = 50;
            TextureInfo_Grid.Columns[1].FillWeight = 50;

            // Update margin + add hook.
            CanvasMargin = (int)CanvasMargin_NumericUpDown.Value;
            CanvasMargin_NumericUpDown.ValueChanged += (s, e) => XnbView_Panel.Invalidate();
        }

        #endregion

        #region Click Handlers

        private void CopyGrid_Button_Click(object sender, EventArgs e)
        {
            // Nothing to copy? Bail out.
            if (TextureInfo_Grid.GetCellCount(DataGridViewElementStates.Visible) == 0)
                return;

            // Select everything.
            TextureInfo_Grid.SelectAll();

            // Get the built-in clipboard object
            DataObject data = TextureInfo_Grid.GetClipboardContent();
            if (data != null)
                Clipboard.SetDataObject(data, true); // true = keep data after app closes.

            // Clear the visual selection so the grid doesn’t stay highlighted.
            TextureInfo_Grid.ClearSelection();

            // Show success message.
            if (Alerts_CheckBox.Checked)
                MessageBox.Show("Data copied to the clipboard successfully.");
        }

        #endregion

        #region UI Events

        private void LoadXnb_Button_Click(object sender, EventArgs e)
        {
            using (var ofd = new OpenFileDialog { Filter = "XNB Texture|*.xnb" })
            {
                if (ofd.ShowDialog() != DialogResult.OK) return;

                // Dispose old resources.
                _bitmap?.Dispose();
                _content?.Dispose();

                // Setup ContentManager.
                var gds = GraphicsDeviceService.AddRef(Handle, ClientSize.Width, ClientSize.Height);
                var services = new ServiceContainer();
                services.AddService<IGraphicsDeviceService>(gds);

                var dir = Path.GetDirectoryName(ofd.FileName);
                var name = Path.GetFileNameWithoutExtension(ofd.FileName);
                _content = new ContentManager(services) { RootDirectory = dir };

                // Load texture and convert to bitmap.
                _texture = _content.Load<Texture2D>(name);
                using (var ms = new MemoryStream())
                {
                    _texture.SaveAsPng(ms, _texture.Width, _texture.Height);
                    ms.Position = 0;
                    _bitmap = new Bitmap(ms);
                    if (_bitmap.PixelFormat != PixelFormat.Format32bppArgb)
                    {
                        var clone = new Bitmap(_bitmap.Width, _bitmap.Height, PixelFormat.Format32bppArgb);
                        using (Graphics g = Graphics.FromImage(clone))
                        {
                            g.DrawImage(_bitmap, new Rectangle(0, 0, clone.Width, clone.Height));
                        }
                        _bitmap.Dispose();
                        _bitmap = clone;
                    }
                }

                // Auto-detect cell size.
                XnbView_Panel.AutoScrollMinSize = new Size(_bitmap.Width, _bitmap.Height);
                XnbView_Panel.Invalidate();

                // Update the datagridview.
                DetectTexturesAndFillGrid(); // Builds _detectedTiles.
                FillTextureInfoGrid();       // Shows them in the selected order.
                UpdateTileCount();           // Update labels to the total tiles highlighted.
            }
        }

        private void XnbView_Panel_Paint(object sender, PaintEventArgs e)
        {
            if (_bitmap == null) return;
            var g = e.Graphics;

            // Work out how big the bitmap will be after zoom, and where to place it.
            float scale      = ZoomScale; // TrackBar → 0.10 … 5.00, etc.
            int scaledWidth  = (int)(_bitmap.Width * scale);
            int scaledHeight = (int)(_bitmap.Height * scale);

            // If the panel is larger than the scaled bitmap, we centre it.
            int extraCenterX = Math.Max((XnbView_Panel.ClientSize.Width - scaledWidth) / 2, 0);
            int extraCenterY = Math.Max((XnbView_Panel.ClientSize.Height - scaledHeight) / 2, 0);

            // The final offset = centring + a fixed CanvasMargin.
            int offsetX = CanvasMargin + extraCenterX;
            int offsetY = CanvasMargin + extraCenterY;

            // Tell WinForms how large the virtual canvas is so the scrollbars are right.
            // Clamp AutoScrollMinSize so it never forces extra scrolling when the image fits.
            int fullH = scaledHeight + CanvasMargin * 2;
            int fullW = scaledWidth + CanvasMargin * 2;

            int minH = Math.Max(fullH, XnbView_Panel.ClientSize.Height);
            int minW = Math.Max(fullW, XnbView_Panel.ClientSize.Width);

            XnbView_Panel.AutoScrollMinSize = new Size(minW, minH);

            // Honor current scrollbar position, *then* push everything by offsetX/Y.
            var scroll = XnbView_Panel.AutoScrollPosition;
            g.TranslateTransform(scroll.X + offsetX, scroll.Y + offsetY);

            // Draw scaled image using nearest-neighbor.
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode   = System.Drawing.Drawing2D.PixelOffsetMode.Half;

            g.DrawImage(_bitmap, new Rectangle(0, 0, scaledWidth, scaledHeight));

            // Draw detected tile rectangles + labels.
            int tileW            = (int)TileU_NumericUpDown.Value;
            int tileH            = (int)TileV_NumericUpDown.Value;
            float baseFontSize   = 3f;
            float scaledFontSize = baseFontSize * ZoomScale;

            // Only use offsets when DynamicLabeling is OFF.
            int uOffset = DynamicLabeling_CheckBox.Checked ? 0 : (int)UOffset_NumericUpDown.Value;
            int vOffset = DynamicLabeling_CheckBox.Checked ? 0 : (int)VOffset_NumericUpDown.Value;
            float uOffsetPx = uOffset * scale;
            float vOffsetPx = vOffset * scale;

            using (var pen = new Pen(Color.FromArgb(180, Color.Red)))
            using (var font = new Font("Consolas", scaledFontSize, FontStyle.Regular, GraphicsUnit.Pixel))
            using (var brush = new SolidBrush(Color.Gold))
            {
                if (!DynamicLabeling_CheckBox.Checked)
                {
                    // ---- SIMPLE UNIFORM GRID WITH OFFSET ----
                    float stepX = tileW * scale;
                    float stepY = tileH * scale;

                    for (int x = 0; x + tileW * scale <= scaledWidth; x += (int)(tileW * scale))
                        for (int y = 0; y + tileH * scale <= scaledHeight; y += (int)(tileH * scale))
                        {
                            float drawX = x + uOffsetPx;
                            float drawY = y + vOffsetPx;

                            var r = new RectangleF(drawX, drawY, stepX, stepY);
                            g.DrawRectangle(pen, r.X, r.Y, r.Width, r.Height);

                            // Label shows the logical texel coords + your offsets.
                            int labelX = (int)(x / scale) + uOffset;
                            int labelY = (int)(y / scale) + vOffset;
                            DrawOutlinedText(g, $"({x / scale}, {y / scale})", font, r.X + 2, r.Y + 2, Color.Yellow, Color.Black);
                        }
                }
                else
                {
                    // ---- DYNAMIC DETECTION GRID ----
                    foreach (var pt in _detectedTiles)
                    {
                        var rect = new RectangleF(pt.X * scale, pt.Y * scale, tileW * scale, tileH * scale);
                        g.DrawRectangle(pen, rect.X, rect.Y, rect.Width, rect.Height);
                        DrawOutlinedText(g, $"({pt.X}, {pt.Y})", font, rect.X + 2, rect.Y + 2, Color.Yellow, Color.Black);
                    }
                }
            }
        }

        #endregion

        #region Helpers

        private void DetectTexturesAndFillGrid()
        {
            // Clear previously detected tiles and UI rows.
            _detectedTiles.Clear();
            // TextureInfo_Grid.Rows.Clear();
        
            // Constants for tile size and gap thresholds.
            int tileSize                = (int)TileSize_NumericUpDown.Value;                // Size of each box.
            int initialGapThreshold     = (int)InitialGapThreshold_NumericUpDown.Value;     // Expected top transparent rows before first sprite.
            int initialGapExtendedLimit = (int)InitialGapExtendedLimit_NumericUpDown.Value; // Max rows to search deeper for first sprite.
            int gapThreshold            = (int)GapThreshold_NumericUpDown.Value;            // Large gap threshold to detect new sprites.
            int seamGap                 = (int)SeamGap_NumericUpDown.Value;                 // Max transparent rows defining a seam (split sprite).
        
            int texW = _bitmap.Width;  // Texture width.
            int texH = _bitmap.Height; // Texture height.
        
            // Helper: Returns true if the entire row (in this column slice) is transparent.
            bool IsTransparentRow(int x, int row)
            {
                if (row < 0 || row >= texH) return true;     // Out of bounds = transparent.
        
                for (int dx = 0; dx < tileSize && x + dx < texW; dx++)
                    if (_bitmap.GetPixel(x + dx, row).A > 0) // Check alpha channel.
                        return false;                        // Pixel not transparent.
        
                return true; // Whole row transparent.
            }
        
            // Loop over columns, stepping by tileSize (18 pixels).
            for (int x = 0; x + tileSize <= texW; x += tileSize)
            {
                int y = 0;                       // Current scanning Y position in column.
                int previousBottomY = -tileSize; // Bottom Y of last placed box (start invalid).

                // ----- 1) INITIAL SPRITE SEARCH -----
                // Count transparent rows at the top up to initialGapThreshold.
                int blankRows = 0;
                while (y < initialGapThreshold && y < texH && IsTransparentRow(x, y))
                {
                    blankRows++;
                    y++;
                }
        
                bool foundInitial = false;
                if (blankRows >= initialGapThreshold)
                {
                    // If all initial rows transparent, search deeper up to extended limit.
                    int scan = y;
                    while (scan < initialGapExtendedLimit && scan < texH && IsTransparentRow(x, scan))
                        scan++;
        
                    // If found first solid pixel before extended limit, place first box.
                    if (scan < initialGapExtendedLimit && scan < texH && !IsTransparentRow(x, scan))
                    {
                        // Calculate overshoot past expected top gap and pull box up accordingly.
                        int overshoot = scan - initialGapThreshold;
                        int boxY      = scan - Math.Max(0, overshoot);
        
                        // Clamp boxY within image bounds.
                        if (boxY + tileSize > texH) boxY = texH - tileSize;
                        if (boxY < 0)               boxY = 0;
        
                        // Add detected tile rectangle and log row info.
                        _detectedTiles.Add(new Rectangle(x, boxY, tileSize, tileSize));
                        // TextureInfo_Grid.Rows.Add($"{x},{boxY}", previousBottomY >= 0 ? boxY - previousBottomY : 0);
        
                        previousBottomY = boxY + tileSize; // Update bottom Y of last box.
                        y               = boxY + tileSize; // Move scanning position below this box.
                        foundInitial    = true;
                    }
                }
        
                // If no initial box found, start scanning from top (y = 0).
                if (!foundInitial) y = 0;

                // ----- 2) MAIN VERTICAL DETECTION -----
                while (y + tileSize <= texH)
                {
                    int scan = y;
                    int transparentCount = 0;
        
                    // Count transparent rows from current y down.
                    while (scan < texH && IsTransparentRow(x, scan))
                    {
                        transparentCount++;
                        scan++;
                    }
        
                    // 2-a) Large transparent gap detected — treat as new sprite start.
                    if (transparentCount >= gapThreshold)
                    {
                        // Find next non-transparent row after large gap.
                        while (scan < texH && IsTransparentRow(x, scan)) scan++;
        
                        // Add new detected sprite box if fully inside bounds.
                        if (scan + tileSize <= texH)
                        {
                            _detectedTiles.Add(new Rectangle(x, scan, tileSize, tileSize));
                            // TextureInfo_Grid.Rows.Add($"{x},{scan}", previousBottomY >= 0 ? scan - previousBottomY : 0);
        
                            previousBottomY = scan + tileSize;
                        }
        
                        y = scan + tileSize; // Advance scanning position.
                        continue;            // Continue detecting further down.
                    }
        
                    // 2-b) Seam detection: Check for exactly two transparent rows indicating sprite split.
                    bool foundSeam = false;
                    while (scan + 2 < texH)
                    {
                        // Condition: Two transparent rows followed by solid pixel row.
                        if (IsTransparentRow(x, scan) &&
                            IsTransparentRow(x, scan + 1) &&
                            !IsTransparentRow(x, scan + 2))
                        {
                            int spriteTop = scan + 2;             // Top of lower half sprite.
                            int boxY      = spriteTop - tileSize; // Proposed upper half box Y.
        
                            // Determine if this is the first box in column.
                            bool isFirst   = previousBottomY < 0;
                            // Decide if we can use boxY or must fallback to 0 (top).
                            // 'boxY >= 18' - 18 or other variable.
                            bool useBoxY   = !isFirst && boxY >= tileSize && boxY + tileSize <= texH;
                            int upperY     = useBoxY ? boxY : 0;
        
                            // Add upper half box if not already present.
                            if (!_detectedTiles.Any(r => r.X == x && r.Y == upperY))
                            {
                                _detectedTiles.Add(new Rectangle(x, upperY, tileSize, tileSize));
                                // TextureInfo_Grid.Rows.Add($"{x},{upperY}", upperY - previousBottomY);
                                previousBottomY = upperY + tileSize;
                            }
        
                            // Snap lower half up to previous bottom if gap ≤ seamGap, else keep original.
                            int lowerY = (spriteTop - previousBottomY <= seamGap)
                                         ? previousBottomY
                                         : spriteTop;
        
                            // Add lower half box.
                            _detectedTiles.Add(new Rectangle(x, lowerY, tileSize, tileSize));
                            // TextureInfo_Grid.Rows.Add($"{x},{lowerY}", owerY - previousBottomY);
                            previousBottomY = lowerY + tileSize;
        
                            y = previousBottomY; // Continue scanning below this sprite.
                            foundSeam = true;
                            break;
                        }
                        scan++;
                    }
        
                    if (!foundSeam)
                        break; // No more sprites/seams in this column; break loop.
                }
            }
        }

        private void FillTextureInfoGrid()
        {
            TextureInfo_Grid.Rows.Clear();

            if (_detectedTiles.Count == 0) return;

            // Pick the sort that matches the chosen radio button.
            IEnumerable<Rectangle> ordered =
                ColumnSorting_RadioButton.Checked
                ? _detectedTiles       // 1) column major.
                    .OrderBy(r => r.X) //   lowest X (left column) first….
                    .ThenBy(r => r.Y)  //   …then top-to-bottom.
                : _detectedTiles       // 2) row major.
                    .OrderBy(r => r.Y) //   top row first….
                    .ThenBy(r => r.X); //   …then left-to-right.

            // Re-compute the "Gap" column in a minimal way.
            int prevRowY = -1;    // Used only in row-major.
            int prevBottomY = -1; // Used only in column-major.
            int prevRightX = -1;  // Used only in row-major.
            int tileSize = (int)TileSize_NumericUpDown.Value;

            foreach (var r in ordered)
            {
                int gap = 0;

                if (ColumnSorting_RadioButton.Checked)
                {
                    // Vertical gap from previous rectangle in the SAME column.
                    if (prevBottomY >= 0 && r.X == ordered.First().X) // Same column.
                        gap = r.Y - prevBottomY;
                    prevBottomY = r.Y + tileSize;
                }
                else
                {
                    // Horizontal gap inside the SAME row.
                    if (r.Y == prevRowY && prevRightX >= 0)
                        gap = r.X - prevRightX;
                    else
                        gap = 0; // New row → no vertical "gap above" meaning.
                    prevRowY = r.Y;
                    prevRightX = r.X + tileSize;
                }

                TextureInfo_Grid.Rows.Add($"{r.X},{r.Y}", gap);
            }
        }

        private void UpdateTileCount()
        {
            int count = 0;

            // Dynamic mode – just use what the detector found.
            if (DynamicLabeling_CheckBox.Checked)
            {
                count = _detectedTiles.Count;
            }
            // Uniform-grid mode – calculate how many rectangles will be drawn.
            else if (_bitmap != null)
            {
                int tileW = (int)TileU_NumericUpDown.Value;
                int tileH = (int)TileV_NumericUpDown.Value;
                int uOff = (int)UOffset_NumericUpDown.Value; // Can be 0 / positive / negative.
                int vOff = (int)VOffset_NumericUpDown.Value;

                // Region actually covered by the grid.
                int usableW = _bitmap.Width - uOff;
                int usableH = _bitmap.Height - vOff;

                // Round up → include the last partial cell if there is one.
                int cols = (int)Math.Ceiling(usableW / (double)tileW);
                int rows = (int)Math.Ceiling(usableH / (double)tileH);

                count = Math.Max(cols, 0) * Math.Max(rows, 0);
            }

            // Update total tiles founnd + do alerts.
            TileCount_Label.Text = $"Tile Count: {count}";

            if (Alerts_CheckBox.Checked)
                MessageBox.Show($"Tile Count: {count}");
        }

        private void DrawOutlinedText(Graphics g, string text, Font font, float x, float y, Color fillColor, Color outlineColor)
        {
            using (var outlineBrush = new SolidBrush(outlineColor))
            using (var fillBrush = new SolidBrush(fillColor))
            {
                // Outline offsets.
                int[] dx = { -1, 1, 0, 0 };
                int[] dy = { 0, 0, -1, 1 };

                for (int i = 0; i < dx.Length; i++)
                    g.DrawString(text, font, outlineBrush, x + dx[i], y + dy[i]);

                // Main fill.
                g.DrawString(text, font, fillBrush, x, y);
            }
        }
        #endregion

        #region Service Container & GraphicsDeviceService

        public class ServiceContainer : IServiceProvider
        {
            private readonly Dictionary<Type, object> services = new Dictionary<Type, object>();
            public void AddService<T>(T service) => services[typeof(T)] = service;
            public object GetService(Type serviceType) => services.TryGetValue(serviceType, out var s) ? s : null;
        }

        class GraphicsDeviceService : IGraphicsDeviceService
        {
            private static GraphicsDeviceService singletonInstance;
            private static int referenceCount;
            private GraphicsDevice graphicsDevice;
            private readonly PresentationParameters parameters;

            private GraphicsDeviceService(IntPtr windowHandle, int width, int height)
            {
                parameters = new PresentationParameters
                {
                    BackBufferWidth = Math.Max(width, 1),
                    BackBufferHeight = Math.Max(height, 1),
                    BackBufferFormat = SurfaceFormat.Color,
                    DepthStencilFormat = DepthFormat.Depth24,
                    DeviceWindowHandle = windowHandle,
                    PresentationInterval = PresentInterval.Immediate,
                    IsFullScreen = false
                };
                graphicsDevice = new GraphicsDevice(GraphicsAdapter.DefaultAdapter, GraphicsProfile.HiDef, parameters);
            }

            public static GraphicsDeviceService AddRef(IntPtr windowHandle, int width, int height)
            {
                if (Interlocked.Increment(ref referenceCount) == 1)
                {
                    singletonInstance = new GraphicsDeviceService(windowHandle, width, height);
                }
                return singletonInstance;
            }

            public void Release(bool disposing)
            {
                if (Interlocked.Decrement(ref referenceCount) == 0 && disposing)
                {
                    DeviceDisposing?.Invoke(this, EventArgs.Empty);
                    graphicsDevice.Dispose();
                    graphicsDevice = null;
                }
            }

            public void ResetDevice(int width, int height)
            {
                DeviceResetting?.Invoke(this, EventArgs.Empty);
                parameters.BackBufferWidth = Math.Max(parameters.BackBufferWidth, width);
                parameters.BackBufferHeight = Math.Max(parameters.BackBufferHeight, height);
                graphicsDevice.Reset(parameters);
                DeviceReset?.Invoke(this, EventArgs.Empty);
            }

            public GraphicsDevice GraphicsDevice => graphicsDevice;
            public event EventHandler<EventArgs> DeviceCreated;
            public event EventHandler<EventArgs> DeviceDisposing;
            public event EventHandler<EventArgs> DeviceReset;
            public event EventHandler<EventArgs> DeviceResetting;
        }
        #endregion
    }
}