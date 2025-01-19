using HeThongDocTruyen.BLL;
using HeThongDocTruyen.Model;
using HeThongDocTruyen.Model.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeThongDocTruyen.UI.UserForm
{
    public partial class QuanLyTruyen : UserControl
    {
        Database db = new Database();

        private BLL_QuanLyTruyen TruyenBLL;

        private Timer TheLoaiTimer, DanhMucTimer;

        //---------------------------------------------------------------------------------------------------------------------------------------

        public QuanLyTruyen()
        {
            InitializeComponent();

            TruyenBLL = new BLL_QuanLyTruyen(new Database().GetConnectionString());

            loadDataTruyen();

            TheLoaiTimer = new Timer();
            TheLoaiTimer.Interval = 1000;
            TheLoaiTimer.Tick += (s, e) => LoadChonTheLoai();
            TheLoaiTimer.Start();

            DanhMucTimer = new Timer();
            DanhMucTimer.Interval = 1000;
            DanhMucTimer.Tick += (s, e) => LoadChonDanhMuc();
            DanhMucTimer.Start();

        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        private void LoadChonDanhMuc()
        {
            string connectionString = new Database().GetConnectionString();
            string query = "SELECT IDDanhMuc, TenDanhMuc FROM DanhMucTruyen";


            var selectedValue = comboBox_DanhMuc.SelectedValue;

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox_DanhMuc.DisplayMember = "TenDanhMuc";
            comboBox_DanhMuc.ValueMember = "IDDanhMuc";
            comboBox_DanhMuc.DataSource = dt;


            if (selectedValue != null && dt.AsEnumerable().Any(row => row["IDDanhMuc"].ToString() == selectedValue.ToString()))
            {
                comboBox_DanhMuc.SelectedValue = selectedValue;
            }
            else
            {

                comboBox_DanhMuc.SelectedIndex = 0;
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        private void LoadChonTheLoai()
        {
            string connectionString = new Database().GetConnectionString();
            string query = "SELECT IDTheLoai, TenTheLoai FROM TheLoaiTruyen";


            var selectedValue = comboBox_TheLoai.SelectedValue;

            SqlDataAdapter da = new SqlDataAdapter(query, connectionString);
            DataTable dt = new DataTable();
            da.Fill(dt);

            comboBox_TheLoai.DisplayMember = "TenTheLoai";
            comboBox_TheLoai.ValueMember = "IDTheLoai";
            comboBox_TheLoai.DataSource = dt;


            if (selectedValue != null && dt.AsEnumerable().Any(row => row["IDTheLoai"].ToString() == selectedValue.ToString()))
            {
                comboBox_TheLoai.SelectedValue = selectedValue;
            }
            else
            {

                comboBox_TheLoai.SelectedIndex = 0;
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        public void loadDataTruyen()
        {
            try
            {
                data_main.DataSource = TruyenBLL.getListTruyen();

            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" , MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        public void ClearData()
        {
            textBox_TenTruyen.Text = "";
            textBox_LuotDoc.Text = "";
            textBox_TacGia.Text = "";
            textBox_MoTaNgan.Text = "";
            pictureBox_AnhTruyen.Image = null;
            comboBox_DanhMuc.SelectedValue = -1;
            comboBox_TheLoai.SelectedValue = -1;
            dateTimePicker_NgayDang.Value = DateTime.Now;

        }
        //---------------------------------------------------------------------------------------------------------------------------------------

        private void pictureBox_Load_Click(object sender, EventArgs e)
        {
            loadDataTruyen();
            MessageBox.Show("Đã tải lại dữ liệu thành công ! ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        private void button_DonThongTin_Click(object sender, EventArgs e)
        {
            ClearData();
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        private void button_Them_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox_DanhMuc.SelectedValue == null || comboBox_TheLoai.SelectedValue == null)
                {
                    MessageBox.Show("Vui lòng chọn danh mục và thể loại hợp lệ!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                Truyen truyen = new Truyen
                {
                    TenTruyen = textBox_TenTruyen.Text,
                    TacGia = textBox_TacGia.Text,
                    MoTa = textBox_MoTaNgan.Text,
                    AnhTruyen = this.imagePath,
                    IDDanhMuc = (int)comboBox_DanhMuc.SelectedValue,
                    IDTheLoai = (int)comboBox_TheLoai.SelectedValue,
                    NgayDang = dateTimePicker_NgayDang.Value
                };

                if (!int.TryParse(textBox_LuotDoc.Text, out int soLuotDoc))
                {
                    MessageBox.Show("Số lượt đọc phải là số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                truyen.SoLuotDoc = soLuotDoc;

                TruyenBLL.AddNewTruyen(truyen);

                loadDataTruyen();
                ClearData();

                MessageBox.Show("Thêm truyện thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm truyện: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        private string imagePath;
        private void button_ThemAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image files (*.jpg, *.png)|*.jpg;*.png" // CHỌN LOẠI ẢNH 
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                pictureBox_AnhTruyen.ImageLocation = imagePath;
            }
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        // Lưu một ảnh vào thư mục trên ổ đĩa và trả về đường dẫn đầy đủ của ảnh đó.
        private string SaveImageAndGetPath()
        {
            // Lưu ảnh vào thư mục trong thư mục người dùng (AppData)
            string directoryImageNhanVien = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "HeThongDocTruyen", "AnhTruyen");

            if (!Directory.Exists(directoryImageNhanVien))
            {
                Directory.CreateDirectory(directoryImageNhanVien);
            }

            // Đặt tên file hình ảnh là duy nhất
            string imageFileName = $"{Guid.NewGuid()}.jpg";
            string destinationPath = Path.Combine(directoryImageNhanVien, imageFileName);
            pictureBox_AnhTruyen.Image.Save(destinationPath, ImageFormat.Jpeg); // Lưu ảnh vào đĩa

            return destinationPath;
        }

        //-------------------------------------------------------------------------------------------------------------------------------
        // Lấy đường dẫn ảnh của một sản phẩm từ cơ sở dữ liệu SQL Server dựa trên mã sản phẩm 
        private string GetExistingImagePath(int maSp)
        {
            // Lấy đường dẫn ảnh cũ từ cơ sở dữ liệu
            string imagePath = string.Empty;
            string query = "SELECT AnhTruyen FROM Truyen WHERE IDTruyen = @MaTruyen";

            using (SqlConnection connection = new SqlConnection(db.GetConnectionString()))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@MaTruyen", maSp);
                    imagePath = (string)command.ExecuteScalar();
                }
            }

            return imagePath;
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
        private void data_main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || data_main.Rows[e.RowIndex] == null)
            {
                MessageBox.Show("Vui lòng chọn mục thay đổi thông tin !", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow rowst = data_main.Rows[e.RowIndex];

                textBox_TenTruyen.Text = rowst.Cells["TenTruyen"]?.Value?.ToString() ?? string.Empty;

                string imageData = rowst.Cells["AnhTruyen"]?.Value?.ToString();
                if (!string.IsNullOrEmpty(imageData) && File.Exists(imageData))
                {
                    pictureBox_AnhTruyen.Image = Image.FromFile(imageData);
                }
                else
                {
                    pictureBox_AnhTruyen.Image = null;
                }


                textBox_TacGia.Text = rowst.Cells["TacGia"]?.Value?.ToString() ?? string.Empty;
                textBox_MoTaNgan.Text = rowst.Cells["MoTa"]?.Value?.ToString() ?? string.Empty;

                if (rowst.Cells["NgayDang"]?.Value != null && rowst.Cells["NgayDang"].Value != DBNull.Value)
                {
                    dateTimePicker_NgayDang.Value = Convert.ToDateTime(rowst.Cells["NgayDang"].Value);
                }
                else
                {
                    dateTimePicker_NgayDang.Value = DateTime.Now;
                }


                if (rowst.Cells["IDDanhMuc"]?.Value != null && rowst.Cells["IDDanhMuc"].Value != DBNull.Value)
                {
                    int manhomsp = Convert.ToInt32(rowst.Cells["IDDanhMuc"].Value);
                    comboBox_DanhMuc.SelectedValue = manhomsp;
                }
                else
                {
                    comboBox_DanhMuc.SelectedIndex = -1;
                }


                if (rowst.Cells["IDTheLoai"]?.Value != null && rowst.Cells["IDTheLoai"].Value != DBNull.Value)
                {
                    int manhomsp = Convert.ToInt32(rowst.Cells["IDTheLoai"].Value);
                    comboBox_TheLoai.SelectedValue = manhomsp;
                }
                else
                {
                    comboBox_TheLoai.SelectedIndex = -1;
                }

                textBox_LuotDoc.Text = rowst.Cells["SoLuotDoc"]?.Value?.ToString() ?? string.Empty;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        private void button_CapNhat_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn truyện trong bảng để cập nhật thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {

                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn thay đổi thông tin này ! ", "Thông báo ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                Truyen truyen = new Truyen
                {
                IDTruyen = Convert.ToInt32(data_main.CurrentRow.Cells["IDTruyen"].Value),
                TenTruyen = textBox_TenTruyen.Text.Trim(),
                TacGia = textBox_TacGia.Text.Trim(),
                MoTa = textBox_MoTaNgan.Text.Trim(),
                IDDanhMuc = (int)comboBox_DanhMuc.SelectedValue,
                IDTheLoai = (int)comboBox_TheLoai.SelectedValue,
                NgayDang = dateTimePicker_NgayDang.Value
            };

            if (!int.TryParse(textBox_LuotDoc.Text, out int soLuotDoc))
            {
                MessageBox.Show("Số lượt đọc phải là số nguyên!", "Lỗi nhập liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            truyen.SoLuotDoc = soLuotDoc;

          
            if (pictureBox_AnhTruyen.Image != null)
            {
                truyen.AnhTruyen = SaveImageAndGetPath(); 
            }
            else
            {
                truyen.AnhTruyen = GetExistingImagePath(truyen.IDTruyen); 
            }

          
                TruyenBLL.UpdateNewTruyen(truyen);
                MessageBox.Show("Cập nhật thông tin truyện thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataTruyen(); 
                ClearData(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật truyện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------


        private void textBox_TimKiem_TextChanged(object sender, EventArgs e)
        {
            try
            {
                string keyword = textBox_TimKiem.Text.Trim();
                DataTable dataTable = TruyenBLL.SearchListTruyen(keyword);
                data_main.DataSource = dataTable;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            try
            {
                string searchKeyword = textBox_TimKiem.Text.Trim();

                if (string.IsNullOrEmpty(searchKeyword))
                {
                    MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                int resultCount = TruyenBLL.CountListTruyen(searchKeyword);
                MessageBox.Show($"Đã tìm thấy {resultCount} kết quả!", "Kết quả tìm kiếm", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resultCount > 0)
                {
                    // Hiển thị danh sách kết quả
                    DataTable dt = TruyenBLL.SearchListTruyen(searchKeyword);
                    data_main.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("Không có kết quả tìm kiếm phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    data_main.DataSource = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------

        private void btn_XemChiTiet_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox_TenTruyen.Text.Trim()))
            {
                MessageBox.Show("Vui lòng chọn tên truyện từ bảng để xem!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string tenTruyen = textBox_TenTruyen.Text;

            string connectionString = db.GetConnectionString();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
            SELECT 
                Truyen.TenTruyen, 
                Truyen.TacGia, 
                Truyen.MoTa, 
                Truyen.SoLuotDoc, 
                DanhMucTruyen.TenDanhMuc, 
                TheLoaiTruyen.TenTheLoai, 
                Truyen.AnhTruyen
            FROM 
                Truyen
            INNER JOIN 
                DanhMucTruyen ON Truyen.IDDanhMuc = DanhMucTruyen.IDDanhMuc
            INNER JOIN 
                TheLoaiTruyen ON Truyen.IDTheLoai = TheLoaiTruyen.IDTheLoai
            WHERE 
                Truyen.TenTruyen = @TenTruyen";

                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@TenTruyen", tenTruyen);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    string tacGia = reader["TacGia"].ToString();
                    string moTa = reader["MoTa"].ToString();
                    string luotDoc = reader["SoLuotDoc"].ToString();
                    string danhMuc = reader["TenDanhMuc"].ToString();
                    string theLoai = reader["TenTheLoai"].ToString();
                    Image anhTruyen = Image.FromFile(reader["AnhTruyen"].ToString());

                    // Khởi tạo form và truyền dữ liệu
                    ChiTietThongTinTruyen chiTietForm = new ChiTietThongTinTruyen();
                    chiTietForm.SetTruyenDetails(tenTruyen, tacGia, moTa, luotDoc, danhMuc, theLoai, anhTruyen);
                    chiTietForm.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy thông tin chi tiết!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        // HÀM XỬ LÍ NÚT XUẤT FILE -> EXCEL

        private void btn_File_Click(object sender, EventArgs e)
        {
            try
            {

                DataTable dt = (DataTable)data_main.DataSource;

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Xóa cột trong bảng 
                if (dt.Columns.Contains("AnhTruyen"))
                {
                    dt.Columns.Remove("AnhTruyen");
                }

                if (dt.Columns.Contains("MoTa"))
                {
                    dt.Columns.Remove("MoTa");
                }

                using (var workbook = new ClosedXML.Excel.XLWorkbook())
                {
                 
                    var worksheet = workbook.Worksheets.Add("Danh sách truyện");
                    worksheet.Cell(1, 1).Value = "Danh sách truyện";
                    worksheet.Cell(2, 1).InsertTable(dt);                
                    int colNgay = dt.Columns.Contains("NgayDang") ? dt.Columns["NgayDang"].Ordinal + 1 : -1;                   
                    worksheet.Columns().AdjustToContents();

                 
                    if (colNgay > 0)
                    {
                        worksheet.Column(colNgay).Style.DateFormat.Format = "dd/MM/yyyy";
                    }                 

                    // Lưu file
                    SaveFileDialog saveFileDialog = new SaveFileDialog
                    {
                        Filter = "Excel Files|*.xlsx",
                        Title = "Lưu file Excel",
                        FileName = "Danh sách truyện.xlsx"
                    };

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        workbook.SaveAs(saveFileDialog.FileName);
                        loadDataTruyen(); 
                        MessageBox.Show("Xuất file thành công !", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Có lỗi khi xuất file: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //---------------------------------------------------------------------------------------------------------------------------------------
        private void button_Xoa_Click(object sender, EventArgs e)
        {
            if (data_main.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn truyện trong bảng để xóa !" , "Thông báo " , MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
        
            try
            {
                DialogResult resultDelete = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin này ! " , "Thông báo " , MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultDelete == DialogResult.Yes)
                {

                int id = Convert.ToInt32(data_main.CurrentRow.Cells["IDTruyen"].Value);
                TruyenBLL.DeleteTruyenNow(id);
                MessageBox.Show("Xóa thông tin truyện thành công !", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadDataTruyen();
                ClearData();
                }
            } catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error" , MessageBoxButtons.OK, MessageBoxIcon.Error);  
            }
        }
        //---------------------------------------------------------------------------------------------------------------------------------------
    }
}
