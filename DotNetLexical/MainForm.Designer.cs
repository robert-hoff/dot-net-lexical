using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DotNetLexical
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ComponentResourceManager resources = new ComponentResourceManager(typeof(MainForm));
            this.menuStrip = new MenuStrip();
            this.OpenFileButton = new ToolStripMenuItem();
            this.div1 = new ToolStripTextBox();
            this.boldButton = new ToolStripMenuItem();
            this.italicButton = new ToolStripMenuItem();
            this.underlineButton = new ToolStripMenuItem();
            this.codeInlineButton = new ToolStripMenuItem();
            this.div2 = new ToolStripTextBox();
            this.editorViewButton = new ToolStripMenuItem();
            this.sourceViewButton = new ToolStripMenuItem();
            this.editingActionsComboBox = new ToolStripComboBox();
            this.statusBar = new StatusStrip();
            this.statusBarLabel = new ToolStripStatusLabel();
            this.mainPanel = new Panel();
            this.menuStrip.SuspendLayout();
            this.statusBar.SuspendLayout();
            this.SuspendLayout();
            //
            // menuStrip
            //
            this.menuStrip.ImageScalingSize = new Size(24, 24);
            this.menuStrip.Items.AddRange(new ToolStripItem[] {
            this.OpenFileButton,
            this.div1,
            this.boldButton,
            this.italicButton,
            this.underlineButton,
            this.codeInlineButton,
            this.div2,
            this.editorViewButton,
            this.sourceViewButton,
            this.editingActionsComboBox});
            this.menuStrip.Location = new Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new Size(800, 27);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            //
            // OpenFileButton
            //
            this.OpenFileButton.AutoToolTip = true;
            this.OpenFileButton.Image = ((Image)(resources.GetObject("openFileToolStripMenuItem.Image")));
            this.OpenFileButton.ImageScaling = ToolStripItemImageScaling.None;
            this.OpenFileButton.Name = "openFileToolStripMenuItem";
            this.OpenFileButton.Size = new Size(28, 23);
            this.OpenFileButton.ToolTipText = "Open file";
            this.OpenFileButton.Click += new EventHandler(this.OpenFileButton_Click);
            //
            // vertical divider
            //
            this.div1.BackColor = SystemColors.Control;
            this.div1.BorderStyle = BorderStyle.None;
            this.div1.Enabled = false;
            this.div1.ReadOnly = true;
            this.div1.Size = new Size(10, 23);
            this.div1.Text = "|";
            this.div1.TextBoxTextAlign = HorizontalAlignment.Center;
            //
            // boldButton
            //
            this.boldButton.Font = new Font("Segoe UI", 10F, FontStyle.Bold, GraphicsUnit.Point);
            this.boldButton.Name = "bToolStripMenuItem1";
            this.boldButton.Size = new Size(30, 23);
            this.boldButton.Text = "B";
            this.boldButton.Click += new EventHandler(this.BoldButton_Click);
            //
            // italicButton
            //
            this.italicButton.Font = new Font("Rockwell", 10F, FontStyle.Italic, GraphicsUnit.Point);
            this.italicButton.Name = "iToolStripMenuItem1";
            this.italicButton.Size = new Size(24, 23);
            this.italicButton.Text = "I";
            this.italicButton.Click += new EventHandler(this.ItalicButton_Click);
            //
            // underlineButton
            //
            this.underlineButton.Font = new Font("Segoe UI", 10F, FontStyle.Underline, GraphicsUnit.Point);
            this.underlineButton.Name = "uToolStripMenuItem1";
            this.underlineButton.Size = new Size(31, 23);
            this.underlineButton.Text = "U";
            this.underlineButton.Click += new EventHandler(this.UnderlineButton_Click);
            //
            // codeInlineButton
            //
            this.codeInlineButton.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            this.codeInlineButton.Name = "codeToolStripMenuItem1";
            this.codeInlineButton.Size = new Size(41, 23);
            this.codeInlineButton.Text = "<>";
            this.codeInlineButton.Click += new EventHandler(this.CodeInlineButton_Click);
            //
            // vertical divider
            //
            this.div2.BackColor = SystemColors.Control;
            this.div2.BorderStyle = BorderStyle.None;
            this.div2.Enabled = false;
            this.div2.ReadOnly = true;
            this.div2.Size = new Size(10, 23);
            this.div2.Text = "|";
            this.div2.TextBoxTextAlign = HorizontalAlignment.Center;
            //
            // editorViewButton
            //
            this.editorViewButton.Image = ((Image)(resources.GetObject("editorViewToolStripMenuItem.Image")));
            this.editorViewButton.ImageScaling = ToolStripItemImageScaling.None;
            this.editorViewButton.Name = "editorViewToolStripMenuItem";
            this.editorViewButton.Size = new Size(28, 23);
            this.editorViewButton.Click += new EventHandler(this.EditViewButton_Click);
            //
            // sourceViewButton
            //
            this.sourceViewButton.Image = ((Image)(resources.GetObject("sourceViewToolStripMenuItem.Image")));
            this.sourceViewButton.ImageScaling = ToolStripItemImageScaling.None;
            this.sourceViewButton.Name = "sourceViewToolStripMenuItem";
            this.sourceViewButton.Size = new Size(28, 23);
            this.sourceViewButton.Click += new EventHandler(this.SourceViewButton_Click);
            //
            // editingActionsComboBox
            //
            this.editingActionsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.editingActionsComboBox.Name = "toolStripComboBox1";
            this.editingActionsComboBox.Size = new Size(121, 23);
            //
            // statusBar
            //
            this.statusBar.Items.AddRange(new ToolStripItem[] {
            this.statusBarLabel});
            this.statusBar.Location = new Point(0, 428);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new Size(800, 22);
            this.statusBar.TabIndex = 1;
            this.statusBar.Text = "";
            //
            // statusBarLabel
            //
            this.statusBarLabel.Name = "statusBarLabel";
            this.statusBarLabel.Size = new Size(10, 17);
            this.statusBarLabel.Text = "[statusbar]";
            //
            // mainPanel
            //
            this.mainPanel.Dock = DockStyle.Fill;
            this.mainPanel.Location = new Point(0, 27);
            this.mainPanel.Name = "panel1";
            this.mainPanel.Size = new Size(800, 401);
            this.mainPanel.TabIndex = 2;
            //
            // MainForm
            //
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(800, 450);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormWebView";
            this.Text = "Html Editor";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusBar.ResumeLayout(false);
            this.statusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Panel mainPanel;
        private MenuStrip menuStrip;
        private ToolStripMenuItem OpenFileButton;
        private ToolStripTextBox div1;
        private ToolStripMenuItem boldButton;
        private ToolStripMenuItem italicButton;
        private ToolStripMenuItem underlineButton;
        private ToolStripMenuItem codeInlineButton;
        private ToolStripTextBox div2;
        private ToolStripMenuItem editorViewButton;
        private ToolStripMenuItem sourceViewButton;
        public ToolStripComboBox editingActionsComboBox;
        private StatusStrip statusBar;
        private ToolStripStatusLabel statusBarLabel;
    }
}
