using System.Windows.Forms;
using System.Reflection;
using System.Linq;
using System;

namespace XNBUVExplorer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            #region Embedded-DLL Resolver

            //  When the CLR can’t find a referenced assembly on disk, this handler
            //  looks inside the executable’s resources and loads it from there.
            //  (Handy for "single-file" deployments.)
            AppDomain.CurrentDomain.AssemblyResolve += (s, args) =>
            {
                // The DLL the CLR is looking for (e.g. “Foo.dll”).
                var asmName = new AssemblyName(args.Name).Name + ".dll";

                // Our own executable.
                var me = Assembly.GetExecutingAssembly();

                // Find a resource that ends with “…Foo.dll”.
                var resource = me.GetManifestResourceNames()
                                 .FirstOrDefault(r => r.EndsWith(asmName));

                if (resource == null) return null; // Not embedded → bail out.

                // Read the embedded DLL bytes and load them.
                using (var str = me.GetManifestResourceStream(resource))
                {
                    var data = new byte[str.Length];
                    str.Read(data, 0, data.Length);
                    return Assembly.Load(data);
                }
            };
            #endregion

            #region WinForms Boilerplate

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            #endregion

            #region Run Main Form w/ Global Exception Trap

            try
            {
                Application.Run(new MainForm());
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.ToString(),
                    "Unhandled exception",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                Clipboard.SetText(ex.ToString());
            }
            #endregion
        }
    }
}