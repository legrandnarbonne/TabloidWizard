using System;
using System.IO;

namespace TabloidWizard.Classes
{
    public static class DirectoryTool
    {
        public static void Copy(string sourceDirectory, string targetDirectory, string[] exclude = null)
        {
            DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
            DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);

            CopyAll(diSource, diTarget, exclude);
        }

        public static void CopyAll(DirectoryInfo source, DirectoryInfo target, string[] exclude = null)
        {
            Directory.CreateDirectory(target.FullName);

            // Copy each file into the new directory.
            foreach (FileInfo fi in source.GetFiles())
            {
                var relative = fi.FullName.Substring(source.FullName.Length + 1);

                if (!isEcluded(relative,exclude))
                {
                    Console.WriteLine(@"Copying {0}\{1}", target.FullName, fi.Name);
                    fi.CopyTo(Path.Combine(target.FullName, fi.Name), true);
                }
            }

            // Copy each subdirectory using recursion.
            foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
            {
                DirectoryInfo nextTargetSubDir =
                    target.CreateSubdirectory(diSourceSubDir.Name);
                CopyAll(diSourceSubDir, nextTargetSubDir);
            }
        }

        private static bool isEcluded(string relative, string[] exclude)
        {
            if (exclude == null) return false;
            foreach (string s in exclude)
                if (string.Equals(relative, s, StringComparison.OrdinalIgnoreCase)) return true;

            return false;
        }
    }
}
