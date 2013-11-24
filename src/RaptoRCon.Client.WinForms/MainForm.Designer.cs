namespace RaptoRCon.Client.WinForms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.Label hostNameLabel;
            System.Windows.Forms.Label portLabel;
            System.Windows.Forms.Label commandLabel;
            System.Windows.Forms.Label gamesLabel;
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.Label passwordLabel;
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.connectionsContainer = new System.Windows.Forms.SplitContainer();
            this.connectionsDataGridView = new System.Windows.Forms.DataGridView();
            this.hostNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.portDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.connectionsMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.connectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.disconnectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mainFormViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gamesComboBox = new System.Windows.Forms.ComboBox();
            this.gamesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.removeButton = new System.Windows.Forms.Button();
            this.addConnectionButton = new System.Windows.Forms.Button();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.hostNameTextBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.contentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.packetsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewButtonColumn1 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            hostNameLabel = new System.Windows.Forms.Label();
            portLabel = new System.Windows.Forms.Label();
            commandLabel = new System.Windows.Forms.Label();
            gamesLabel = new System.Windows.Forms.Label();
            passwordLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsContainer)).BeginInit();
            this.connectionsContainer.Panel1.SuspendLayout();
            this.connectionsContainer.Panel2.SuspendLayout();
            this.connectionsContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsDataGridView)).BeginInit();
            this.connectionsMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.packetsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // hostNameLabel
            // 
            hostNameLabel.AutoSize = true;
            hostNameLabel.Location = new System.Drawing.Point(12, 59);
            hostNameLabel.Name = "hostNameLabel";
            hostNameLabel.Size = new System.Drawing.Size(63, 13);
            hostNameLabel.TabIndex = 0;
            hostNameLabel.Text = "Host Name:";
            // 
            // portLabel
            // 
            portLabel.AutoSize = true;
            portLabel.Location = new System.Drawing.Point(12, 85);
            portLabel.Name = "portLabel";
            portLabel.Size = new System.Drawing.Size(29, 13);
            portLabel.TabIndex = 2;
            portLabel.Text = "Port:";
            // 
            // commandLabel
            // 
            commandLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            commandLabel.AutoSize = true;
            commandLabel.Location = new System.Drawing.Point(14, 480);
            commandLabel.Name = "commandLabel";
            commandLabel.Size = new System.Drawing.Size(84, 13);
            commandLabel.TabIndex = 1;
            commandLabel.Text = "CommandString:";
            // 
            // gamesLabel
            // 
            gamesLabel.AutoSize = true;
            gamesLabel.Location = new System.Drawing.Point(12, 32);
            gamesLabel.Name = "gamesLabel";
            gamesLabel.Size = new System.Drawing.Size(38, 13);
            gamesLabel.TabIndex = 7;
            gamesLabel.Text = "Game:";
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.connectionsContainer);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.AutoScroll = true;
            this.mainContainer.Panel2.Controls.Add(this.sendButton);
            this.mainContainer.Panel2.Controls.Add(commandLabel);
            this.mainContainer.Panel2.Controls.Add(this.commandTextBox);
            this.mainContainer.Panel2.Controls.Add(this.dataGridView1);
            this.mainContainer.Size = new System.Drawing.Size(938, 522);
            this.mainContainer.SplitterDistance = 312;
            this.mainContainer.TabIndex = 0;
            // 
            // connectionsContainer
            // 
            this.connectionsContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionsContainer.Location = new System.Drawing.Point(0, 0);
            this.connectionsContainer.Name = "connectionsContainer";
            this.connectionsContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // connectionsContainer.Panel1
            // 
            this.connectionsContainer.Panel1.AutoScroll = true;
            this.connectionsContainer.Panel1.Controls.Add(this.connectionsDataGridView);
            // 
            // connectionsContainer.Panel2
            // 
            this.connectionsContainer.Panel2.AutoScroll = true;
            this.connectionsContainer.Panel2.Controls.Add(passwordLabel);
            this.connectionsContainer.Panel2.Controls.Add(this.passwordTextBox);
            this.connectionsContainer.Panel2.Controls.Add(gamesLabel);
            this.connectionsContainer.Panel2.Controls.Add(this.gamesComboBox);
            this.connectionsContainer.Panel2.Controls.Add(this.removeButton);
            this.connectionsContainer.Panel2.Controls.Add(this.addConnectionButton);
            this.connectionsContainer.Panel2.Controls.Add(portLabel);
            this.connectionsContainer.Panel2.Controls.Add(this.portTextBox);
            this.connectionsContainer.Panel2.Controls.Add(hostNameLabel);
            this.connectionsContainer.Panel2.Controls.Add(this.hostNameTextBox);
            this.connectionsContainer.Size = new System.Drawing.Size(312, 522);
            this.connectionsContainer.SplitterDistance = 334;
            this.connectionsContainer.TabIndex = 0;
            // 
            // connectionsDataGridView
            // 
            this.connectionsDataGridView.AutoGenerateColumns = false;
            this.connectionsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.connectionsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.hostNameDataGridViewTextBoxColumn,
            this.portDataGridViewTextBoxColumn,
            this.State});
            this.connectionsDataGridView.ContextMenuStrip = this.connectionsMenuStrip;
            this.connectionsDataGridView.DataSource = this.connectionsBindingSource;
            this.connectionsDataGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.connectionsDataGridView.Location = new System.Drawing.Point(0, 0);
            this.connectionsDataGridView.Name = "connectionsDataGridView";
            this.connectionsDataGridView.Size = new System.Drawing.Size(312, 334);
            this.connectionsDataGridView.TabIndex = 0;
            // 
            // hostNameDataGridViewTextBoxColumn
            // 
            this.hostNameDataGridViewTextBoxColumn.DataPropertyName = "HostName";
            this.hostNameDataGridViewTextBoxColumn.HeaderText = "HostName";
            this.hostNameDataGridViewTextBoxColumn.Name = "hostNameDataGridViewTextBoxColumn";
            this.hostNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.hostNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // portDataGridViewTextBoxColumn
            // 
            this.portDataGridViewTextBoxColumn.DataPropertyName = "Port";
            this.portDataGridViewTextBoxColumn.HeaderText = "Port";
            this.portDataGridViewTextBoxColumn.Name = "portDataGridViewTextBoxColumn";
            this.portDataGridViewTextBoxColumn.ReadOnly = true;
            this.portDataGridViewTextBoxColumn.Width = 80;
            // 
            // State
            // 
            this.State.DataPropertyName = "State";
            this.State.HeaderText = "State";
            this.State.Name = "State";
            this.State.ReadOnly = true;
            this.State.Width = 150;
            // 
            // connectionsMenuStrip
            // 
            this.connectionsMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectToolStripMenuItem,
            this.disconnectToolStripMenuItem});
            this.connectionsMenuStrip.Name = "connectionsMenuStrip";
            this.connectionsMenuStrip.Size = new System.Drawing.Size(134, 48);
            // 
            // connectToolStripMenuItem
            // 
            this.connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            this.connectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.connectToolStripMenuItem.Text = "Connect";
            this.connectToolStripMenuItem.Click += new System.EventHandler(this.connectToolStripMenuItem_Click);
            // 
            // disconnectToolStripMenuItem
            // 
            this.disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            this.disconnectToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.disconnectToolStripMenuItem.Text = "Disconnect";
            this.disconnectToolStripMenuItem.Click += new System.EventHandler(this.disconnectToolStripMenuItem_Click);
            // 
            // connectionsBindingSource
            // 
            this.connectionsBindingSource.DataMember = "Connections";
            this.connectionsBindingSource.DataSource = this.mainFormViewModelBindingSource;
            this.connectionsBindingSource.CurrentChanged += new System.EventHandler(this.connectionsBindingSource_CurrentChanged);
            // 
            // mainFormViewModelBindingSource
            // 
            this.mainFormViewModelBindingSource.DataSource = typeof(RaptoRCon.Client.WinForms.MainFormViewModel);
            // 
            // gamesComboBox
            // 
            this.gamesComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.mainFormViewModelBindingSource, "CurrentGameId", true));
            this.gamesComboBox.DataSource = this.gamesBindingSource;
            this.gamesComboBox.DisplayMember = "Name";
            this.gamesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gamesComboBox.FormattingEnabled = true;
            this.gamesComboBox.Location = new System.Drawing.Point(81, 29);
            this.gamesComboBox.Name = "gamesComboBox";
            this.gamesComboBox.Size = new System.Drawing.Size(226, 21);
            this.gamesComboBox.TabIndex = 6;
            this.gamesComboBox.ValueMember = "Id";
            // 
            // gamesBindingSource
            // 
            this.gamesBindingSource.DataMember = "Games";
            this.gamesBindingSource.DataSource = this.mainFormViewModelBindingSource;
            // 
            // removeButton
            // 
            this.removeButton.Location = new System.Drawing.Point(245, 134);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(62, 23);
            this.removeButton.TabIndex = 5;
            this.removeButton.Text = "Remove";
            this.removeButton.UseVisualStyleBackColor = true;
            this.removeButton.Click += new System.EventHandler(this.removeButton_Click);
            // 
            // addConnectionButton
            // 
            this.addConnectionButton.Location = new System.Drawing.Point(185, 134);
            this.addConnectionButton.Name = "addConnectionButton";
            this.addConnectionButton.Size = new System.Drawing.Size(54, 23);
            this.addConnectionButton.TabIndex = 4;
            this.addConnectionButton.Text = "Add";
            this.addConnectionButton.UseVisualStyleBackColor = true;
            this.addConnectionButton.Click += new System.EventHandler(this.addConnectionButton_Click);
            // 
            // portTextBox
            // 
            this.portTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormViewModelBindingSource, "Port", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.portTextBox.Location = new System.Drawing.Point(81, 82);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(226, 20);
            this.portTextBox.TabIndex = 3;
            // 
            // hostNameTextBox
            // 
            this.hostNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormViewModelBindingSource, "HostName", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.hostNameTextBox.Location = new System.Drawing.Point(81, 56);
            this.hostNameTextBox.Name = "hostNameTextBox";
            this.hostNameTextBox.Size = new System.Drawing.Size(226, 20);
            this.hostNameTextBox.TabIndex = 1;
            // 
            // sendButton
            // 
            this.sendButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.sendButton.Location = new System.Drawing.Point(504, 475);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(106, 23);
            this.sendButton.TabIndex = 5;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click_1);
            // 
            // commandTextBox
            // 
            this.commandTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.commandTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.connectionsBindingSource, "CommandStringString", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.commandTextBox.Location = new System.Drawing.Point(104, 477);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(394, 20);
            this.commandTextBox.TabIndex = 2;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.contentDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.packetsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(616, 457);
            this.dataGridView1.TabIndex = 0;
            // 
            // contentDataGridViewTextBoxColumn
            // 
            this.contentDataGridViewTextBoxColumn.DataPropertyName = "Content";
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.contentDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.contentDataGridViewTextBoxColumn.HeaderText = "Content";
            this.contentDataGridViewTextBoxColumn.Name = "contentDataGridViewTextBoxColumn";
            this.contentDataGridViewTextBoxColumn.Width = 500;
            // 
            // packetsBindingSource
            // 
            this.packetsBindingSource.DataMember = "Packets";
            this.packetsBindingSource.DataSource = this.connectionsBindingSource;
            // 
            // dataGridViewButtonColumn1
            // 
            this.dataGridViewButtonColumn1.DataPropertyName = "CloseCommand";
            this.dataGridViewButtonColumn1.HeaderText = "Delete";
            this.dataGridViewButtonColumn1.Name = "dataGridViewButtonColumn1";
            this.dataGridViewButtonColumn1.ReadOnly = true;
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new System.Drawing.Point(12, 111);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new System.Drawing.Size(56, 13);
            passwordLabel.TabIndex = 8;
            passwordLabel.Text = "Password:";
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.mainFormViewModelBindingSource, "Password", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.passwordTextBox.Location = new System.Drawing.Point(81, 108);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.Size = new System.Drawing.Size(226, 20);
            this.passwordTextBox.TabIndex = 9;
            this.passwordTextBox.UseSystemPasswordChar = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 522);
            this.Controls.Add(this.mainContainer);
            this.Name = "MainForm";
            this.Text = "RaptoRCon";
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            this.mainContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.connectionsContainer.Panel1.ResumeLayout(false);
            this.connectionsContainer.Panel2.ResumeLayout(false);
            this.connectionsContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.connectionsContainer)).EndInit();
            this.connectionsContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionsDataGridView)).EndInit();
            this.connectionsMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.connectionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainFormViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gamesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.packetsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer mainContainer;
        private System.Windows.Forms.SplitContainer connectionsContainer;
        private System.Windows.Forms.BindingSource mainFormViewModelBindingSource;
        private System.Windows.Forms.DataGridView connectionsDataGridView;
        private System.Windows.Forms.BindingSource connectionsBindingSource;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.TextBox hostNameTextBox;
        private System.Windows.Forms.Button addConnectionButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource packetsBindingSource;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.Button removeButton;
        private System.Windows.Forms.DataGridViewButtonColumn dataGridViewButtonColumn1;
        private System.Windows.Forms.ComboBox gamesComboBox;
        private System.Windows.Forms.BindingSource gamesBindingSource;
        private System.Windows.Forms.ContextMenuStrip connectionsMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem connectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem disconnectToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn hostNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn portDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn contentDataGridViewTextBoxColumn;
        private System.Windows.Forms.TextBox passwordTextBox;

    }
}

