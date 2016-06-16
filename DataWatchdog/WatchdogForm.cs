using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows.Forms;

namespace DataWatchdog
{
    public partial class WatchdogForm : Form
    {
        public WatchdogForm()
        {
            InitializeComponent();
            autoShutdownMenuItem.Checked = Properties.Settings.Default.AutoShutdown;
            VerifyOrInit();
        }

        private void exitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void resetMenuItem_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void shutdownBtn_Click(object sender, EventArgs e)
        {
            Shutdown();
            Hide();
        }

        private void closeNotifyBtn_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void WatchdogForm_Load(object sender, EventArgs e)
        {
            Hide();
        }

        private void autoShutdownMenuItem_Click(object sender, EventArgs e)
        {
            autoShutdownMenuItem.Checked = !autoShutdownMenuItem.Checked;
            Properties.Settings.Default.AutoShutdown = autoShutdownMenuItem.Checked;
            Properties.Settings.Default.Save();
        }

        private string _decoyFolderName = Properties.Settings.Default.FolderName;
        private string _decoyFilename = Properties.Settings.Default.Filename;
        private string _decoyContent = Properties.Settings.Default.Content;
        private List<FileSystemWatcher> _watchers = new List<FileSystemWatcher>();

        private void VerifyOrInit(bool reset = false)
        {
            var fixedOnly = Properties.Settings.Default.FixedOnly;
            // Verify or init watcher folders
            var driverList = RetrieveDrives(fixedOnly);
            foreach (var driveName in driverList)
            {
                if (!VerifyOrdInitWatchFolder(driveName, reset))
                    MessageBox.Show(string.Format("{0} not valid!", driveName), "Watch Dog", MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
            }
            // Init folder watcher
            foreach (var driveName in driverList)
            {
                var watcher = new FileSystemWatcher(driveName + _decoyFolderName);
                watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size;
                watcher.Created += WatcherEventHandler;
                watcher.Renamed += WatcherEventHandler;
                watcher.Changed += WatcherEventHandler;
                watcher.EnableRaisingEvents = true;
                _watchers.Add(watcher);
            }
        }

        private void WatcherEventHandler(object sender, FileSystemEventArgs fileSystemEventArgs)
        {
            // Sound the alarm
            var target = fileSystemEventArgs.FullPath;
            MessageBox.Show($"Alarm on {target}", "Watch Dog", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private bool VerifyOrdInitWatchFolder(string driveName, bool reset)
        {
            var watchFolder = new DirectoryInfo(driveName + _decoyFolderName);
            if (watchFolder.Exists)
            {
                try
                {
                    if (reset)
                    {
                        watchFolder.Delete(true);
                    }
                    else
                    {
                        var files = watchFolder.GetFiles();
                        // check file number
                        if (files.Length != 1) return false;
                        // check filename
                        if (!files[0].Name.Equals(_decoyFilename)) return false;
                        // check file content
                        if (!files[0].OpenText().ReadLine().Equals(_decoyContent)) return false;
                        return true;
                    }
                }
                catch (Exception)
                {
                    return false;
                }
            }
            // init watch folder
            try
            {
                watchFolder.Create();
                var decoyFile = new FileInfo($"{watchFolder.FullName}\\{_decoyFilename}");
                using (var sw = new StreamWriter(decoyFile.Create()))
                {
                    for (int i = 0; i < 1000; i++)
                    {
                        sw.WriteLine(_decoyContent);
                    }
                    sw.Close();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        private List<string> RetrieveDrives(bool fixedOnly)
        {
            var driveList = new List<string>();
            var drives = DriveInfo.GetDrives();
            foreach (var driveInfo in drives)
            {
                var driveName = driveInfo.Name;
                switch (driveInfo.DriveType)
                {
                    case System.IO.DriveType.Fixed:
                    case System.IO.DriveType.Removable:
                        if (fixedOnly)
                        {
                            if (!IsExternalDisk(driveName)) driveList.Add(driveName);
                        }
                        else
                            driveList.Add(driveName);
                        break;
                    case DriveType.Unknown:
                        break;
                    case DriveType.NoRootDirectory:
                        break;
                    case DriveType.Network:
                        break;
                    case DriveType.CDRom:
                        break;
                    case DriveType.Ram:
                        break;
                    default:
                        break;
                }
            }
            return driveList;
        }

        private bool IsExternalDisk(string driveLetter)
        {
            bool retVal = false;
            driveLetter = driveLetter.TrimEnd('\\');

            // browse all USB WMI physical disks
            foreach (ManagementObject drive in new ManagementObjectSearcher("select DeviceID, MediaType,InterfaceType from Win32_DiskDrive").Get())
            {
                // associate physical disks with partitions
                ManagementObjectCollection partitionCollection = new ManagementObjectSearcher(String.Format("associators of {{Win32_DiskDrive.DeviceID='{0}'}} " + "where AssocClass = Win32_DiskDriveToDiskPartition", drive["DeviceID"])).Get();

                foreach (ManagementObject partition in partitionCollection)
                {
                    if (partition != null)
                    {
                        // associate partitions with logical disks (drive letter volumes)
                        ManagementObjectCollection logicalCollection = new ManagementObjectSearcher(String.Format("associators of {{Win32_DiskPartition.DeviceID='{0}'}} " + "where AssocClass= Win32_LogicalDiskToPartition", partition["DeviceID"])).Get();

                        foreach (ManagementObject logical in logicalCollection)
                        {
                            if (logical != null)
                            {
                                // finally find the logical disk entry
                                ManagementObjectCollection.ManagementObjectEnumerator volumeEnumerator = new ManagementObjectSearcher(String.Format("select DeviceID from Win32_LogicalDisk " + "where Name='{0}'", logical["Name"])).Get().GetEnumerator();

                                volumeEnumerator.MoveNext();

                                ManagementObject volume = (ManagementObject)volumeEnumerator.Current;

                                if (driveLetter.ToLowerInvariant().Equals(volume["DeviceID"].ToString().ToLowerInvariant()) &&
                                    (drive["MediaType"].ToString().ToLowerInvariant().Contains("external") || drive["InterfaceType"].ToString().ToLowerInvariant().Contains("usb")))
                                {
                                    retVal = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }

            return retVal;
        }

        private void ShowNotification(string message, bool showShutdown = true, bool autoShutdown = false)
        {
            notifyMessage.Text = message;
            shutdownBtn.Visible = showShutdown;
            var screen = Screen.AllScreens[0];
            Show();
            this.WindowState = FormWindowState.Normal;
            Left = screen.WorkingArea.Right - Width;
            Top = screen.WorkingArea.Bottom - Height;
            if (autoShutdown) Shutdown();
        }

        private void Shutdown()
        {
            var psi = new ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            Process.Start(psi);
        }

        private void Reset()
        {
            ShowNotification("This is a test message!");
        }
    }
}
