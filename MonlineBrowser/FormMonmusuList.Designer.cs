namespace MonlineBrowser
{
    partial class FormMonmusuList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMonmusuList = new System.Windows.Forms.DataGridView();
            this.buttonRefreshMonmusuList = new System.Windows.Forms.Button();
            this.ColumnMonID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonRebirth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonRace = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonElement = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnMonHP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonTension = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonSatiety = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMonFood = new System.Windows.Forms.DataGridViewImageColumn();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonmusuList)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMonmusuList
            // 
            this.dataGridViewMonmusuList.AllowUserToAddRows = false;
            this.dataGridViewMonmusuList.AllowUserToDeleteRows = false;
            this.dataGridViewMonmusuList.AllowUserToResizeColumns = false;
            this.dataGridViewMonmusuList.AllowUserToResizeRows = false;
            this.dataGridViewMonmusuList.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridViewMonmusuList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewMonmusuList.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            this.dataGridViewMonmusuList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMonmusuList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewMonmusuList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewMonmusuList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnMonID,
            this.ColumnMonLevel,
            this.ColumnMonRebirth,
            this.ColumnMonName,
            this.ColumnMonRace,
            this.ColumnMonElement,
            this.ColumnMonHP,
            this.ColumnMonTension,
            this.ColumnMonSatiety,
            this.ColumnMonFood});
            this.dataGridViewMonmusuList.EnableHeadersVisualStyles = false;
            this.dataGridViewMonmusuList.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            this.dataGridViewMonmusuList.Location = new System.Drawing.Point(23, 63);
            this.dataGridViewMonmusuList.MultiSelect = false;
            this.dataGridViewMonmusuList.Name = "dataGridViewMonmusuList";
            this.dataGridViewMonmusuList.ReadOnly = true;
            this.dataGridViewMonmusuList.RowHeadersVisible = false;
            this.dataGridViewMonmusuList.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(17)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Gray;
            this.dataGridViewMonmusuList.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewMonmusuList.RowTemplate.Height = 21;
            this.dataGridViewMonmusuList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridViewMonmusuList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMonmusuList.Size = new System.Drawing.Size(409, 714);
            this.dataGridViewMonmusuList.TabIndex = 4;
            // 
            // buttonRefreshMonmusuList
            // 
            this.buttonRefreshMonmusuList.BackColor = System.Drawing.Color.Transparent;
            this.buttonRefreshMonmusuList.FlatAppearance.BorderColor = System.Drawing.Color.DarkTurquoise;
            this.buttonRefreshMonmusuList.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.buttonRefreshMonmusuList.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefreshMonmusuList.Font = new System.Drawing.Font("Meiryo UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.buttonRefreshMonmusuList.ForeColor = System.Drawing.Color.DarkTurquoise;
            this.buttonRefreshMonmusuList.Location = new System.Drawing.Point(179, 26);
            this.buttonRefreshMonmusuList.Name = "buttonRefreshMonmusuList";
            this.buttonRefreshMonmusuList.Size = new System.Drawing.Size(84, 24);
            this.buttonRefreshMonmusuList.TabIndex = 70;
            this.buttonRefreshMonmusuList.Text = "Refresh";
            this.buttonRefreshMonmusuList.UseVisualStyleBackColor = false;
            this.buttonRefreshMonmusuList.Click += new System.EventHandler(this.buttonRefreshMonmusuList_Click);
            // 
            // ColumnMonID
            // 
            this.ColumnMonID.HeaderText = "*";
            this.ColumnMonID.Name = "ColumnMonID";
            this.ColumnMonID.ReadOnly = true;
            this.ColumnMonID.Width = 25;
            // 
            // ColumnMonLevel
            // 
            this.ColumnMonLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonLevel.HeaderText = "レベル";
            this.ColumnMonLevel.Name = "ColumnMonLevel";
            this.ColumnMonLevel.ReadOnly = true;
            this.ColumnMonLevel.Width = 58;
            // 
            // ColumnMonRebirth
            // 
            this.ColumnMonRebirth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonRebirth.HeaderText = "限界凸破";
            this.ColumnMonRebirth.Name = "ColumnMonRebirth";
            this.ColumnMonRebirth.ReadOnly = true;
            this.ColumnMonRebirth.Width = 77;
            // 
            // ColumnMonName
            // 
            this.ColumnMonName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonName.HeaderText = "名前";
            this.ColumnMonName.Name = "ColumnMonName";
            this.ColumnMonName.ReadOnly = true;
            this.ColumnMonName.Width = 53;
            // 
            // ColumnMonRace
            // 
            this.ColumnMonRace.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonRace.HeaderText = "種族";
            this.ColumnMonRace.Name = "ColumnMonRace";
            this.ColumnMonRace.ReadOnly = true;
            this.ColumnMonRace.Width = 53;
            // 
            // ColumnMonElement
            // 
            this.ColumnMonElement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonElement.HeaderText = "タイプ";
            this.ColumnMonElement.Name = "ColumnMonElement";
            this.ColumnMonElement.ReadOnly = true;
            this.ColumnMonElement.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMonElement.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnMonElement.Width = 55;
            // 
            // ColumnMonHP
            // 
            this.ColumnMonHP.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonHP.HeaderText = "気力";
            this.ColumnMonHP.Name = "ColumnMonHP";
            this.ColumnMonHP.ReadOnly = true;
            this.ColumnMonHP.Width = 53;
            // 
            // ColumnMonTension
            // 
            this.ColumnMonTension.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonTension.HeaderText = "テンション";
            this.ColumnMonTension.Name = "ColumnMonTension";
            this.ColumnMonTension.ReadOnly = true;
            this.ColumnMonTension.Width = 72;
            // 
            // ColumnMonSatiety
            // 
            this.ColumnMonSatiety.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonSatiety.HeaderText = "満腹度";
            this.ColumnMonSatiety.Name = "ColumnMonSatiety";
            this.ColumnMonSatiety.ReadOnly = true;
            this.ColumnMonSatiety.Width = 65;
            // 
            // ColumnMonFood
            // 
            this.ColumnMonFood.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.ColumnMonFood.HeaderText = "好物";
            this.ColumnMonFood.Name = "ColumnMonFood";
            this.ColumnMonFood.ReadOnly = true;
            this.ColumnMonFood.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMonFood.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnMonFood.Width = 53;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(285, 31);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(323, 19);
            this.metroLabel1.TabIndex = 71;
            this.metroLabel1.Text = "※リストの横幅、フォームの横幅は自動調整されます。";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroLabel1.Visible = false;
            // 
            // FormMonmusuList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 800);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.buttonRefreshMonmusuList);
            this.Controls.Add(this.dataGridViewMonmusuList);
            this.MaximizeBox = false;
            this.Name = "FormMonmusuList";
            this.Resizable = false;
            this.Text = "モン娘一覧";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.Load += new System.EventHandler(this.FormMonmusuList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMonmusuList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMonmusuList;
        private System.Windows.Forms.Button buttonRefreshMonmusuList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonID;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonRebirth;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonRace;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMonElement;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonHP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonTension;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMonSatiety;
        private System.Windows.Forms.DataGridViewImageColumn ColumnMonFood;
        private MetroFramework.Controls.MetroLabel metroLabel1;
    }
}