namespace AmazonReviewCrawler
{
    partial class gui
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tbProductCode = new System.Windows.Forms.TextBox();
            this.btnGetData = new System.Windows.Forms.Button();
            this.lbProductCode = new System.Windows.Forms.Label();
            this.gbInput = new System.Windows.Forms.GroupBox();
            this.gbReviewCount = new System.Windows.Forms.GroupBox();
            this.lvReviewCount = new System.Windows.Forms.ListView();
            this.columnDataName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnDataValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txtWorkStatus = new System.Windows.Forms.Label();
            this.gbReviewDetail = new System.Windows.Forms.GroupBox();
            this.lvReviewDetail = new System.Windows.Forms.ListView();
            this.chName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStar = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chContent = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbInput.SuspendLayout();
            this.gbReviewCount.SuspendLayout();
            this.gbReviewDetail.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbProductCode
            // 
            this.tbProductCode.Location = new System.Drawing.Point(6, 33);
            this.tbProductCode.Name = "tbProductCode";
            this.tbProductCode.Size = new System.Drawing.Size(139, 19);
            this.tbProductCode.TabIndex = 0;
            // 
            // btnGetData
            // 
            this.btnGetData.Location = new System.Drawing.Point(151, 31);
            this.btnGetData.Name = "btnGetData";
            this.btnGetData.Size = new System.Drawing.Size(75, 23);
            this.btnGetData.TabIndex = 1;
            this.btnGetData.Text = "取得する";
            this.btnGetData.UseVisualStyleBackColor = true;
            this.btnGetData.Click += new System.EventHandler(this.BtnGetData_Click);
            // 
            // lbProductCode
            // 
            this.lbProductCode.AutoSize = true;
            this.lbProductCode.Location = new System.Drawing.Point(6, 15);
            this.lbProductCode.Name = "lbProductCode";
            this.lbProductCode.Size = new System.Drawing.Size(139, 12);
            this.lbProductCode.TabIndex = 2;
            this.lbProductCode.Text = "Amazonの商品コードを入力";
            // 
            // gbInput
            // 
            this.gbInput.Controls.Add(this.lbProductCode);
            this.gbInput.Controls.Add(this.btnGetData);
            this.gbInput.Controls.Add(this.tbProductCode);
            this.gbInput.Location = new System.Drawing.Point(3, 3);
            this.gbInput.Name = "gbInput";
            this.gbInput.Size = new System.Drawing.Size(240, 73);
            this.gbInput.TabIndex = 3;
            this.gbInput.TabStop = false;
            this.gbInput.Text = "入力箇所";
            // 
            // gbReviewCount
            // 
            this.gbReviewCount.Controls.Add(this.lvReviewCount);
            this.gbReviewCount.Location = new System.Drawing.Point(3, 82);
            this.gbReviewCount.Name = "gbReviewCount";
            this.gbReviewCount.Size = new System.Drawing.Size(145, 172);
            this.gbReviewCount.TabIndex = 4;
            this.gbReviewCount.TabStop = false;
            this.gbReviewCount.Text = "レビュー";
            // 
            // lvReviewCount
            // 
            this.lvReviewCount.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnDataName,
            this.columnDataValue});
            this.lvReviewCount.Location = new System.Drawing.Point(6, 18);
            this.lvReviewCount.Name = "lvReviewCount";
            this.lvReviewCount.Size = new System.Drawing.Size(125, 146);
            this.lvReviewCount.TabIndex = 5;
            this.lvReviewCount.UseCompatibleStateImageBehavior = false;
            this.lvReviewCount.View = System.Windows.Forms.View.Details;
            // 
            // columnDataName
            // 
            this.columnDataName.Text = "データ名";
            // 
            // columnDataValue
            // 
            this.columnDataValue.Text = "値";
            this.columnDataValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtWorkStatus
            // 
            this.txtWorkStatus.AutoSize = true;
            this.txtWorkStatus.Location = new System.Drawing.Point(3, 257);
            this.txtWorkStatus.Name = "txtWorkStatus";
            this.txtWorkStatus.Size = new System.Drawing.Size(41, 12);
            this.txtWorkStatus.TabIndex = 5;
            this.txtWorkStatus.Text = "待機中";
            // 
            // gbReviewDetail
            // 
            this.gbReviewDetail.Controls.Add(this.lvReviewDetail);
            this.gbReviewDetail.Location = new System.Drawing.Point(154, 82);
            this.gbReviewDetail.Name = "gbReviewDetail";
            this.gbReviewDetail.Size = new System.Drawing.Size(385, 172);
            this.gbReviewDetail.TabIndex = 6;
            this.gbReviewDetail.TabStop = false;
            this.gbReviewDetail.Text = "レビュー詳細";
            // 
            // lvReviewDetail
            // 
            this.lvReviewDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chName,
            this.chStar,
            this.chTitle,
            this.chContent});
            this.lvReviewDetail.Location = new System.Drawing.Point(0, 18);
            this.lvReviewDetail.Name = "lvReviewDetail";
            this.lvReviewDetail.Size = new System.Drawing.Size(379, 146);
            this.lvReviewDetail.TabIndex = 0;
            this.lvReviewDetail.UseCompatibleStateImageBehavior = false;
            this.lvReviewDetail.View = System.Windows.Forms.View.Details;
            // 
            // chName
            // 
            this.chName.Text = "名前";
            // 
            // chStar
            // 
            this.chStar.Text = "★";
            // 
            // chTitle
            // 
            this.chTitle.Text = "タイトル";
            // 
            // chContent
            // 
            this.chContent.Text = "内容";
            // 
            // gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbReviewDetail);
            this.Controls.Add(this.txtWorkStatus);
            this.Controls.Add(this.gbReviewCount);
            this.Controls.Add(this.gbInput);
            this.Name = "gui";
            this.Size = new System.Drawing.Size(542, 285);
            this.gbInput.ResumeLayout(false);
            this.gbInput.PerformLayout();
            this.gbReviewCount.ResumeLayout(false);
            this.gbReviewDetail.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbProductCode;
        private System.Windows.Forms.Button btnGetData;
        private System.Windows.Forms.Label lbProductCode;
        private System.Windows.Forms.GroupBox gbInput;
        private System.Windows.Forms.GroupBox gbReviewCount;
        private System.Windows.Forms.ListView lvReviewCount;
        private System.Windows.Forms.ColumnHeader columnDataName;
        private System.Windows.Forms.ColumnHeader columnDataValue;
        private System.Windows.Forms.Label txtWorkStatus;
        private System.Windows.Forms.GroupBox gbReviewDetail;
        private System.Windows.Forms.ListView lvReviewDetail;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chStar;
        private System.Windows.Forms.ColumnHeader chTitle;
        private System.Windows.Forms.ColumnHeader chContent;
    }
}
