namespace RedWood
{
    partial class TreeListView
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.col1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.SuspendLayout();
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.col1});
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowExpandOnDblClick = false;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.treeList1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.treeList1.OptionsSelection.SelectNodesOnRightClick = true;
            this.treeList1.Size = new System.Drawing.Size(750, 378);
            this.treeList1.TabIndex = 0;
            this.treeList1.RowClick += new DevExpress.XtraTreeList.RowClickEventHandler(this.treeList1_RowClick);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.TreeList1_FocusedNodeChanged);
            this.treeList1.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.treeList1_ShowingEditor);
            // 
            // col1
            // 
            this.col1.Caption = "Data";
            this.col1.FieldName = "treeListColumn1";
            this.col1.Name = "col1";
            this.col1.Visible = true;
            this.col1.VisibleIndex = 0;
            // 
            // TreeListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.treeList1);
            this.Name = "TreeListView";
            this.Size = new System.Drawing.Size(750, 378);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn col1;
    }
}
