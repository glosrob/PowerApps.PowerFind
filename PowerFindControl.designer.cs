
namespace XRTSoft.PowerApps.PowerFind
{
    partial class PowerFindControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.ssMain = new System.Windows.Forms.StatusStrip();
            this.tsslMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.chkForms = new System.Windows.Forms.CheckBox();
            this.chkViews = new System.Windows.Forms.CheckBox();
            this.chkWorkflows = new System.Windows.Forms.CheckBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtColumn = new System.Windows.Forms.TextBox();
            this.lblColumn = new System.Windows.Forms.Label();
            this.lblSearching = new System.Windows.Forms.Label();
            this.ComponentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.ssMain.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.AllowUserToAddRows = false;
            this.dgvResults.AllowUserToDeleteRows = false;
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.LightSteelBlue;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvResults.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ComponentType,
            this.NameColumn,
            this.idColumn});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvResults.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvResults.EnableHeadersVisualStyles = false;
            this.dgvResults.Location = new System.Drawing.Point(3, 220);
            this.dgvResults.Margin = new System.Windows.Forms.Padding(10);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowHeadersWidth = 25;
            this.dgvResults.RowTemplate.Height = 40;
            this.dgvResults.Size = new System.Drawing.Size(1117, 886);
            this.dgvResults.TabIndex = 5;
            // 
            // ssMain
            // 
            this.ssMain.ImageScalingSize = new System.Drawing.Size(40, 40);
            this.ssMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsslMain});
            this.ssMain.Location = new System.Drawing.Point(0, 1116);
            this.ssMain.Name = "ssMain";
            this.ssMain.Size = new System.Drawing.Size(1123, 22);
            this.ssMain.TabIndex = 10;
            this.ssMain.Text = "statusStrip1";
            // 
            // tsslMain
            // 
            this.tsslMain.Name = "tsslMain";
            this.tsslMain.Size = new System.Drawing.Size(0, 9);
            // 
            // grpSearch
            // 
            this.grpSearch.Controls.Add(this.chkForms);
            this.grpSearch.Controls.Add(this.chkViews);
            this.grpSearch.Controls.Add(this.chkWorkflows);
            this.grpSearch.Controls.Add(this.btnFind);
            this.grpSearch.Controls.Add(this.txtColumn);
            this.grpSearch.Controls.Add(this.lblColumn);
            this.grpSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSearch.Location = new System.Drawing.Point(7, 3);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1107, 214);
            this.grpSearch.TabIndex = 11;
            this.grpSearch.TabStop = false;
            this.grpSearch.Text = "Options";
            // 
            // chkForms
            // 
            this.chkForms.AutoSize = true;
            this.chkForms.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkForms.Location = new System.Drawing.Point(18, 125);
            this.chkForms.Name = "chkForms";
            this.chkForms.Size = new System.Drawing.Size(151, 43);
            this.chkForms.TabIndex = 3;
            this.chkForms.Text = "Forms";
            this.chkForms.UseVisualStyleBackColor = true;
            // 
            // chkViews
            // 
            this.chkViews.AutoSize = true;
            this.chkViews.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkViews.Location = new System.Drawing.Point(237, 125);
            this.chkViews.Name = "chkViews";
            this.chkViews.Size = new System.Drawing.Size(147, 43);
            this.chkViews.TabIndex = 4;
            this.chkViews.Text = "Views";
            this.chkViews.UseVisualStyleBackColor = true;
            // 
            // chkWorkflows
            // 
            this.chkWorkflows.AutoSize = true;
            this.chkWorkflows.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWorkflows.Location = new System.Drawing.Point(448, 125);
            this.chkWorkflows.Name = "chkWorkflows";
            this.chkWorkflows.Size = new System.Drawing.Size(212, 43);
            this.chkWorkflows.TabIndex = 5;
            this.chkWorkflows.Text = "Workflows";
            this.chkWorkflows.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFind.Location = new System.Drawing.Point(900, 30);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(201, 173);
            this.btnFind.TabIndex = 6;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            // 
            // txtColumn
            // 
            this.txtColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtColumn.Location = new System.Drawing.Point(185, 56);
            this.txtColumn.Name = "txtColumn";
            this.txtColumn.Size = new System.Drawing.Size(535, 45);
            this.txtColumn.TabIndex = 1;
            // 
            // lblColumn
            // 
            this.lblColumn.AutoSize = true;
            this.lblColumn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblColumn.Location = new System.Drawing.Point(16, 62);
            this.lblColumn.Name = "lblColumn";
            this.lblColumn.Size = new System.Drawing.Size(135, 39);
            this.lblColumn.TabIndex = 10;
            this.lblColumn.Text = "Column";
            // 
            // lblSearching
            // 
            this.lblSearching.AutoSize = true;
            this.lblSearching.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.900001F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSearching.Location = new System.Drawing.Point(0, 220);
            this.lblSearching.Name = "lblSearching";
            this.lblSearching.Size = new System.Drawing.Size(198, 39);
            this.lblSearching.TabIndex = 12;
            this.lblSearching.Text = "Searching...";
            this.lblSearching.Visible = false;
            // 
            // ComponentType
            // 
            this.ComponentType.HeaderText = "Component Type";
            this.ComponentType.MinimumWidth = 12;
            this.ComponentType.Name = "ComponentType";
            this.ComponentType.ReadOnly = true;
            this.ComponentType.Width = 150;
            // 
            // NameColumn
            // 
            this.NameColumn.HeaderText = "Name";
            this.NameColumn.MinimumWidth = 12;
            this.NameColumn.Name = "NameColumn";
            this.NameColumn.ReadOnly = true;
            this.NameColumn.Width = 550;
            // 
            // idColumn
            // 
            this.idColumn.HeaderText = "Id";
            this.idColumn.MinimumWidth = 12;
            this.idColumn.Name = "idColumn";
            this.idColumn.ReadOnly = true;
            this.idColumn.Width = 350;
            // 
            // PowerFindControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblSearching);
            this.Controls.Add(this.grpSearch);
            this.Controls.Add(this.ssMain);
            this.Controls.Add(this.dgvResults);
            this.Margin = new System.Windows.Forms.Padding(7, 8, 7, 8);
            this.Name = "PowerFindControl";
            this.Size = new System.Drawing.Size(1123, 1138);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.ssMain.ResumeLayout(false);
            this.ssMain.PerformLayout();
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvResults;
        private System.Windows.Forms.StatusStrip ssMain;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.CheckBox chkForms;
        private System.Windows.Forms.CheckBox chkViews;
        private System.Windows.Forms.CheckBox chkWorkflows;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtColumn;
        private System.Windows.Forms.Label lblColumn;
        private System.Windows.Forms.ToolStripStatusLabel tsslMain;
        private System.Windows.Forms.Label lblSearching;
        private System.Windows.Forms.DataGridViewTextBoxColumn ComponentType;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idColumn;
    }
}
