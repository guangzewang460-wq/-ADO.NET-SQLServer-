using StudentsProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProject.Models;

namespace StudentsProject.Services
{
    public class StudentService
    {
        private readonly StudentDAL _studentDAL;

        public StudentService()
        {
            _studentDAL = new StudentDAL();
        }

        // 获取所有学生
        public List<Student> GetAllStudents()
        {
            return _studentDAL.GetStudents();
        }

        // 按照ID查询学生
        public Student GetStudent(int id)
        {
            var students = _studentDAL.GetStudents();
            var student = students.Find(s => s.Id == id);
            if (student == null)
            {
                student = new Student();
            }
            return student;
            //return students.FirstOrDefault(s => s.Id == id);
        }

        // 删除学生
        public bool DeleteStudent(int id)
        {
            var student = GetStudent(id);
            if(student.Id == 0)
            {
                Console.WriteLine("学生不存在");
                return false;
            }
            return _studentDAL.DeleteStudent(id) > 0;
        }

        // 修改学生信息
        public bool UpdateStudent(Student student)
        {
            if (student.Age <= 0)
            {
                Console.WriteLine("年龄无效！");
                return false;
            }
            return _studentDAL.UpdateStudent(student) > 0;
        }

        // 添加学生
        public bool AddStudent(Student student)
        {
            return _studentDAL.Add(student)>0;
        }


    }
}
