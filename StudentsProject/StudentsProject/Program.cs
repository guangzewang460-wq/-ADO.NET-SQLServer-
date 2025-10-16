using Microsoft.IdentityModel.Tokens;
using StudentsProject.Models;
using StudentsProject.Services;

StudentService studentService = new();

bool exit = false;

while (!exit)
{
    Console.WriteLine("\n=== 学生信息管理系统 ===");
    Console.WriteLine("1. 查看所有学生");
    Console.WriteLine("2. 添加学生");
    Console.WriteLine("3. 删除学生"); 
    Console.WriteLine("4. 修改学生");
    Console.WriteLine("5. 查询学生（按 ID）");
    Console.WriteLine("0. 退出");
    Console.Write("请选择操作：");

    string input = Console.ReadLine();

    switch (input)
    {
        case "1":
            var students = studentService.GetAllStudents();
            Console.WriteLine("所有学生列表：");
            foreach(var student_item in students)
            {
                Console.WriteLine($"{student_item.Id}\t{student_item.Name}\t{student_item.Gender}\t{student_item.Age}\t{student_item.Major}");
            }
            break;
        case "2":
            Circle:
            Console.WriteLine("请输入学生信息：");
            Student newStudent = new Student();
            Console.Write("姓名：");
            newStudent.Name = Console.ReadLine();
            Console.Write("性别：");
            newStudent.Gender = Console.ReadLine();
            Console.Write("年龄：");
            newStudent.Age = int.Parse(Console.ReadLine());
            Console.Write("专业：");
            newStudent.Major = Console.ReadLine();

            if(string.IsNullOrEmpty(newStudent.Name) || string.IsNullOrEmpty(newStudent.Gender)|| string.IsNullOrEmpty(newStudent.Major))
            {
                Console.WriteLine("信息不完整，请重新输入");
                goto Circle;
            }

            if (studentService.AddStudent(newStudent))
            {
                Console.WriteLine("学生添加成功");
            }
            else
            {
                Console.WriteLine("学生添加失败");
            }

            break;
        case "3":
            // 删除学生
            Console.Write("请输入要删除的学生 ID：");
            int deleteId = int.Parse(Console.ReadLine());
            if (studentService.DeleteStudent(deleteId))
            {
                Console.WriteLine("学生删除成功！");
            }
            else
            {
                Console.WriteLine("学生删除失败！");
            }
            break;
        case "4":
            // 修改学生信息
            Console.Write("请输入要修改的学生 ID：");
            int updateId = int.Parse(Console.ReadLine());
            Student studentToUpdate = studentService.GetStudent(updateId);
            if(studentToUpdate.Id == 0)
            {
                Console.WriteLine("学生不存在");
                break;
            }

            Console.WriteLine("请输入新的信息：");
            Console.Write("姓名：");
            studentToUpdate.Name = Console.ReadLine();
            Console.Write("性别：");
            studentToUpdate.Gender = Console.ReadLine();
            Console.Write("年龄：");
            studentToUpdate.Age = int.Parse(Console.ReadLine());
            Console.Write("专业：");
            studentToUpdate.Major = Console.ReadLine();

            if (studentService.UpdateStudent(studentToUpdate))
            {
                Console.WriteLine("学生信息更新成功！");
            }
            else
            {
                Console.WriteLine("学生信息更新失败！");
            }
            break;
        case "5":
            // 查询学生
            Console.Write("请输入学生 ID：");
            int searchId = int.Parse(Console.ReadLine());
            var student = studentService.GetStudent(searchId);

            if (student != null)
            {
                Console.WriteLine($"学生信息：{student.Id}\t{student.Name}\t{student.Gender}\t{student.Age}\t{student.Major}");
            }
            else
            {
                Console.WriteLine("学生不存在！");
            }
            break;
        case "0":
            exit = !exit;
            break;
        default:
            Console.WriteLine("无效的操作，请重试！");
            break;
    }
}