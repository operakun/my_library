using System;
using System.Windows.Forms;

namespace AmazonReviewCrawler
{
    public partial class gui: UserControl
    {
        public gui()
        {
            InitializeComponent();
            tbProductCode.Text = "489100455X";
        }

        private void BtnGetData_Click(object sender, EventArgs e)
        {
            var clawler = new Crawler(tbProductCode.Text);
            if (clawler.GetPageHTML() == false)
            {
                MessageBox.Show("商品コードのページが存在しません");
            }

            string strReviewCount = clawler.GetReviewCount();
            if (strReviewCount == "")
            {
                MessageBox.Show("レビュー数を取得出来ませんでした");
            }
            else
            {
                txtReviewCount.Text = strReviewCount;
            }
            
        }

    }
}
