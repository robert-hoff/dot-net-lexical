using System;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.Web.WebView2.WinForms;

/*
 * .NET Lexical Html Editor
 *
 * Built around the WinForms version of WebView2
 * ref. https://docs.microsoft.com/en-us/microsoft-edge/webview2/webview2-api-reference
 *
 * Dependent on Lexical with some modifications,
 * editing functions have been exposed by attaching them to the document object (javascript).
 *
 * Project website https://github.com/robert-hoff/dot-net-lexical
 *
 *
 *
 */
namespace DotNetLexical
{
    public partial class MainForm : Form
    {
        public WebView2 webView2 { get; private set; }
        private RichTextBox sourceTextBox;
        private FormSettings settings;

        public MainForm()
        {
            InitializeComponent();

            // restore previous size and position of the application window
            settings = new FormSettings();
            StartPosition = FormStartPosition.Manual;
            Location = settings.FormLocation;
            Size = settings.FormSize;

            // WebView2 control
            webView2 = new WebView2();
            webView2.KeyDown += (sender, keyEvent) =>
            {
                WebView2_KeyDown(sender as WebView2, keyEvent, this);
            };
            webView2.Dock = DockStyle.Fill;

            // a textbox to show the html source (not meaningful in it's current form)
            sourceTextBox = new RichTextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                // ReadOnly = true,
                WordWrap = false,
                ScrollBars = RichTextBoxScrollBars.Both
            };
            sourceTextBox.Font = new Font(FontFamily.GenericMonospace, sourceTextBox.Font.Size);
            sourceTextBox.Hide();

            editingActionsComboBox.Items.AddRange(new string[] {
                "Paragraph",
                "Heading 1",
                "Heading 2",
                "Quote",
                "Image",
                "Code block",
                "Table",
                "Equation",
            });
            editingActionsComboBox.SelectedIndex = 0;
            editingActionsComboBox.DropDownClosed += (sender, e) =>
            {
                EditingAction_Selected((sender as ToolStripComboBox).SelectedIndex);
            };
            mainPanel.Controls.Add(webView2);
            mainPanel.Controls.Add(sourceTextBox);
        }

        /*
         * The WebView2 class prevents most keys from being seen
         * Among the visible keys are Esc, F1, F2
         *
         * F1, F2 are implemented as shortcuts for formatHeading1 and formatHeading2 (also
         * provided in the drop down list)
         *
         * Esc closes the application
         *
         */
        private async void WebView2_KeyDown(WebView2 webView2, KeyEventArgs keyEvent, Form mainForm)
        {
            Keys keyData = keyEvent.KeyData;
            Trace.WriteLine($"keyData seen {keyData}");

            if (keyData == (Keys.F1))
            {
                Debug.WriteLine($"ExecuteScriptAsync document.formatHeading1()");
                await webView2.ExecuteScriptAsync("document.formatHeading1()");
            }

            if (keyData == (Keys.F2))
            {
                Debug.WriteLine($"ExecuteScriptAsync document.formatHeading2()");
                await webView2.ExecuteScriptAsync("document.formatHeading2()");
            }

            if (keyData == Keys.Down)
            {
                editingActionsComboBox.Focus();
            }


            // closes application on Esc
            if (keyData == Keys.Escape)
            {
                mainForm.Close();
            }
        }

        private async void EditingAction_Selected(int sel)
        {
            switch (sel)
            {
                case 0:
                    Debug.WriteLine($"ExecuteScriptAsync document.formatParagraph()");
                    await webView2.ExecuteScriptAsync("document.formatParagraph()");
                    break;

                case 1:
                    Debug.WriteLine($"ExecuteScriptAsync document.formatHeading1()");
                    await webView2.ExecuteScriptAsync("document.formatHeading1()");
                    break;

                case 2:
                    Debug.WriteLine($"ExecuteScriptAsync document.formatHeading2()");
                    await webView2.ExecuteScriptAsync("document.formatHeading2()");
                    break;

                case 3:
                    Debug.WriteLine($"ExecuteScriptAsync document.formatQuote()");
                    await webView2.ExecuteScriptAsync("document.formatQuote()");
                    break;

                case 4:
                    Debug.WriteLine($"ExecuteScriptAsync document.imageButtonRef.current.click()");
                    await webView2.ExecuteScriptAsync("document.imageButtonRef.current.click()");
                    break;

                case 5:
                    Debug.WriteLine($"ExecuteScriptAsync document.formatCodeBlock()");
                    await webView2.ExecuteScriptAsync("document.formatCodeBlock()");
                    break;

                case 6:
                    Debug.WriteLine($"ExecuteScriptAsync document.tableButtonRef.current.click()");
                    await webView2.ExecuteScriptAsync("document.tableButtonRef.current.click()");
                    break;

                case 7:
                    Debug.WriteLine($"ExecuteScriptAsync document.equationButtonRef.current.click()");
                    await webView2.ExecuteScriptAsync("document.equationButtonRef.current.click()");
                    break;
            }

            // bring back focus to the web viewer (editing area)
            webView2.Focus();
        }

        private async void BoldButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"document.formatBold()");
            await webView2.ExecuteScriptAsync("document.formatBold()");
        }

        private async void ItalicButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"document.formatItalic()");
            await webView2.ExecuteScriptAsync("document.formatItalic()");
        }

        private async void UnderlineButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"document.formatUnderline()");
            await webView2.ExecuteScriptAsync("document.formatUnderline()");
        }

        private async void CodeInlineButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine($"document.formatCodeInline()");
            await webView2.ExecuteScriptAsync("document.formatCodeInline()");
        }

        private void OpenFileButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Open new file to edit (needs implementation)");
        }

        private void EditViewButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Show edit view (if viewing source - source view needs implementation)");
        }

        private void SourceViewButton_Click(object sender, EventArgs e)
        {
            Debug.WriteLine("Show source view (needs implementation)");
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            settings.FormLocation = Location;
            settings.FormSize = Size;
            settings.Save();
            base.OnClosing(e);
        }

        sealed class FormSettings : ApplicationSettingsBase
        {
            [UserScopedSettingAttribute()]
            [DefaultSettingValueAttribute("100, 100")]
            public Point FormLocation
            {
                get { return (Point)(this["FormLocation"]); }
                set { this["FormLocation"] = value; }
            }
            [UserScopedSettingAttribute()]
            [DefaultSettingValueAttribute("600, 700")]
            public Size FormSize
            {
                get { return (Size)this["FormSize"]; }
                set { this["FormSize"] = value; }
            }
        }
    }
}
