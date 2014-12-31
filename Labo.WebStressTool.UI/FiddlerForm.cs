namespace Labo.WebStressTool.UI
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Windows.Forms;

    using Labo.WebStressTool.Core;
    using Labo.WebStressTool.Fiddler;

    public partial class FiddlerForm : Form
    {
        private readonly FiddlerHttpRequestRecordCollector m_FiddlerHttpRequestRecordCollector;

        public IList<HttpRequestRecord> Records
        {
            get
            {
                return m_FiddlerHttpRequestRecordCollector.Records;
            }
        }

        public FiddlerForm()
        {
            InitializeComponent();

            m_FiddlerHttpRequestRecordCollector = new FiddlerHttpRequestRecordCollector();
            m_FiddlerHttpRequestRecordCollector.HttpRequestRecordReceived += FiddlerHttpRequestRecordCollectorHttpRequestRecordReceived;
            txtFileExtensionsToExclude.Text = @".css|.js|.gif|.jpg|.jpeg|.bmp|.ico|.png|.axd";

            UpdateRecordButtons(false);
        }

        private void FiddlerHttpRequestRecordCollectorHttpRequestRecordReceived(FiddlerHttpRequestRecordCollector collector, HttpRequestRecord record)
        {
            MethodInvoker addListBoxItem = () => listBoxRecord.Items.Add(string.Format("{0}{1} : {2}", record.Method, (record.ResponseStatus > 0) ? string.Format("({0} {1})", record.ResponseStatus, Enum.GetName(typeof(System.Net.HttpStatusCode), record.ResponseStatus)) : null, record.Uri.AbsoluteUri));
            if (listBoxRecord.InvokeRequired)
            {
                listBoxRecord.Invoke(new MethodInvoker(addListBoxItem));
            }
            else
            {
                addListBoxItem();
            }
        }

        private void btnStartRecording_Click(object sender, EventArgs e)
        {
            UpdateRecordButtons(true);

            m_FiddlerHttpRequestRecordCollector.FileExtensionsToExclude = txtFileExtensionsToExclude.Text.Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries).ToList();
            m_FiddlerHttpRequestRecordCollector.HostNamesToCollect = txtDomainsToCollect.Text.Split(new[] { Environment.CommandLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
            m_FiddlerHttpRequestRecordCollector.StartCollecting();
        }

        private void btnStopRecording_Click(object sender, EventArgs e)
        {
            UpdateRecordButtons(false);

            m_FiddlerHttpRequestRecordCollector.StopCollecting();
        }

        private void UpdateRecordButtons(bool started)
        {
            btnStartRecording.Enabled = !started;
            btnStopRecording.Enabled = started;
        }

        private void listBoxRecord_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();

            bool selected = (e.State & DrawItemState.Selected) == DrawItemState.Selected;

            int index = e.Index;
            if (index >= 0 && index < listBoxRecord.Items.Count)
            {
                string text = listBoxRecord.Items[index].ToString();
                Graphics g = e.Graphics;

                using (SolidBrush b = new SolidBrush(e.BackColor))
                {
                    g.FillRectangle(b, e.Bounds);
                }

                using (SolidBrush f = new SolidBrush((text.StartsWith("GET") || text.StartsWith("POST") || selected) ? e.ForeColor : Color.Gray))
                {
                    g.DrawString(text, e.Font, f, listBoxRecord.GetItemRectangle(index).Location);
                }
            }

            e.DrawFocusRectangle();
        }

        private void btnClearCollectedData_Click(object sender, EventArgs e)
        {
            m_FiddlerHttpRequestRecordCollector.ClearData();
            listBoxRecord.Items.Clear();
        }

        private void FiddlerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_FiddlerHttpRequestRecordCollector.StopCollecting();
        }
    }
}
