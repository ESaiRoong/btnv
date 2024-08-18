using System.Windows.Forms;

namespace MenuShip
{
    public partial class Form1 : Form
    {
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void checkBoxNam_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBoxNu_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }
        private void btnNhapAnh_Click(object sender, EventArgs e)
        {
            // Tạo OpenFileDialog để chọn ảnh
            OpenFileDialog openFileDialog = new OpenFileDialog();

            // Chỉ cho phép chọn file ảnh (các định dạng phổ biến như .jpg, .jpeg, .png, .bmp, .gif)
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";

            // Hiển thị hộp thoại chọn file và kiểm tra xem người dùng có chọn file hay không
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Hiển thị ảnh đã chọn trong PictureBox
                pictureBox1.Image = Image.FromFile(openFileDialog.FileName);

                // Để ảnh hiển thị vừa với kích thước của PictureBox
                pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }
        private void btnXacNhan_Click(object sender, EventArgs e)
        {

            string hoTen = txtHoTen.Text;
            string mssv = txtMSSV.Text;
            Image anh = pictureBox1.Image;


            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(mssv) || anh == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin và chọn ảnh.");
                return;
            }

            // Tạo  SinhVien mới
            SinhVien sinhVienMoi = new SinhVien
            {
                HoTen = hoTen,
                MSSV = mssv,
                Anh = anh
            };

            // Thêm sv vào danh sách
            danhSachSinhVien.Add(sinhVienMoi);


            MessageBox.Show("Đã thêm sinh viên vào danh sách!");

            //  chuẩn bị cho lần nhập tiếp theo
            txtHoTen.Clear();
            txtMSSV.Clear();
            pictureBox1.Image = null;
        }



    }
    public class SinhVien
    {
        public string HoTen { get; set; }
        public string MSSV { get; set; }
        public Image Anh { get; set; }
    }
}