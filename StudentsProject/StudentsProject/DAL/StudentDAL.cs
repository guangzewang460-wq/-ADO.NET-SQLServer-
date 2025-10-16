using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Models;
using StudentsProject.Utils;
using Microsoft.Data.SqlClient;

namespace StudentsProject.DAL
{
    public class StudentDAL
    {
        public List<Student> GetStudents()
        {
            List<Student> list = new();
            string sql = "select * from Students";

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new(sql, conn))
                using(SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new Student
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            Gender = reader.GetString(2),
                            Age = reader.GetInt32(3),
                            Major = reader.GetString(4)
                        });
                    }
                }
            }
            return list;
        }

        // 新增学生
        public int Add(Student s)
        {
            string sql = "INSERT INTO Students (Name, Gender, Age, Major) VALUES (@Name, @Gender, @Age, @Major)";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Gender", s.Gender);
                    cmd.Parameters.AddWithValue("@Age", s.Age);
                    cmd.Parameters.AddWithValue("@Major", s.Major);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 删除学生
        public int DeleteStudent(int id)
        {
            string sql = "delete from Students where Id = @Id";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        // 修改学生信息
        public int UpdateStudent(Student s)
        {
            string sql = "update Students set Gender=@Gender,Age=@Age,Major=@Major,Name=@Name where Id=@Id";
            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@Name", s.Name);
                    cmd.Parameters.AddWithValue("@Gender", s.Gender);
                    cmd.Parameters.AddWithValue("@Age", s.Age);
                    cmd.Parameters.AddWithValue("@Major", s.Major);
                    cmd.Parameters.AddWithValue("@Id", s.Id);

                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
