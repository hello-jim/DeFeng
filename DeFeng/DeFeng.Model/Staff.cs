﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeFeng.Model
{
    public class Staff
    {
        private int id;
        private string account;
        private Department department;
        private string password;//密码
        private string staffNumber; //员工号
        private string staffName;//员工名
        private string birthdayType; //生日类别
        private string idCard;//身份证号码
        private string submitHouseDate;//出生年月
        private string sex; //性别
        private string age; //  年龄
        private string birthday; //生日
        private string marital;//  婚姻状况
        private string education;//  学历
        private string major;// 专业
        private string bloodType; //  血型
        private string entry_time;//入职时间
        private string entry_status;//入职状态
        private string probation;//试用期
        private string height; //高度
        private string probation_salary;//使用薪水
        private string salary;//转正薪水
        private string politics;//政治面貌
        private string title;//职称
        private string nation;//民族
        private string email;//邮箱
        private string tel;//家庭电话
        private string officTel;//办公电话
        private string accountType;//户口类别
        private string accountAddress;//户口所在地
        private string place_origin;//籍贯
        private string address;//现住址
        private string application_method;// 应聘渠道
        private string family_members;//家庭成员
        private string family_relationship;//关系
        private string family_occupation;//职业
        private string landscape;//政治面貌
        private string family_company;//所在单位
        private string family_contact;//联系方式
        private string entry_unit;//入职单位
        private string entry_department;//入职部门
        private string entry_position;//入职岗位
        private string leader;//直属领导
        private string part_time_job;//兼职部门
        private string part_time_position;//兼职岗位
        private string branch_manager;//分行经理
        private string site_manager;//现场经理
        private string hr_clerk;//人事文员
        private string hr_manager;//人事经理
        private string general_manager;//总经理
        private string login_name;//登录名
        private string access_authority;//分配权限
        

        private string phone;//电话号码

        public int ID
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }


        public Department Department
        {
            get
            {
                return department;
            }

            set
            {
                department = value;
            }
        }


        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }


        public string IdCard
        {
            get
            {
                return idCard;
            }

            set
            {
                idCard = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }

        public string Family_contact
        {
            get
            {
                return Family_contact1;
            }

            set
            {
                Family_contact1 = value;
            }
        }

        public string StaffNumber
        {
            get
            {
                return staffNumber;
            }

            set
            {
                staffNumber = value;
            }
        }

        public string StaffName
        {
            get
            {
                return staffName;
            }

            set
            {
                staffName = value;
            }
        }

        public string BirthdayType
        {
            get
            {
                return birthdayType;
            }

            set
            {
                birthdayType = value;
            }
        }

        public string SubmitHouseDate
        {
            get
            {
                return submitHouseDate;
            }

            set
            {
                submitHouseDate = value;
            }
        }

        public string Sex
        {
            get
            {
                return sex;
            }

            set
            {
                sex = value;
            }
        }

        public string Age
        {
            get
            {
                return age;
            }

            set
            {
                age = value;
            }
        }

        public string Birthday
        {
            get
            {
                return birthday;
            }

            set
            {
                birthday = value;
            }
        }

        public string Marital
        {
            get
            {
                return marital;
            }

            set
            {
                marital = value;
            }
        }

        public string Education
        {
            get
            {
                return education;
            }

            set
            {
                education = value;
            }
        }

        public string Major
        {
            get
            {
                return major;
            }

            set
            {
                major = value;
            }
        }

        public string BloodType
        {
            get
            {
                return bloodType;
            }

            set
            {
                bloodType = value;
            }
        }

        public string Entry_time
        {
            get
            {
                return entry_time;
            }

            set
            {
                entry_time = value;
            }
        }

        public string Entry_status
        {
            get
            {
                return entry_status;
            }

            set
            {
                entry_status = value;
            }
        }

        public string Probation
        {
            get
            {
                return probation;
            }

            set
            {
                probation = value;
            }
        }

        public string Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public string Probation_salary
        {
            get
            {
                return probation_salary;
            }

            set
            {
                probation_salary = value;
            }
        }

        public string Salary
        {
            get
            {
                return salary;
            }

            set
            {
                salary = value;
            }
        }

        public string Politics
        {
            get
            {
                return politics;
            }

            set
            {
                politics = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Nation
        {
            get
            {
                return nation;
            }

            set
            {
                nation = value;
            }
        }

        public string Email
        {
            get
            {
                return email;
            }

            set
            {
                email = value;
            }
        }

        public string Tel
        {
            get
            {
                return tel;
            }

            set
            {
                tel = value;
            }
        }

        public string OfficTel
        {
            get
            {
                return officTel;
            }

            set
            {
                officTel = value;
            }
        }

        public string AccountType
        {
            get
            {
                return accountType;
            }

            set
            {
                accountType = value;
            }
        }

        public string AccountAddress
        {
            get
            {
                return accountAddress;
            }

            set
            {
                accountAddress = value;
            }
        }

        public string Place_origin
        {
            get
            {
                return place_origin;
            }

            set
            {
                place_origin = value;
            }
        }

        public string Address
        {
            get
            {
                return address;
            }

            set
            {
                address = value;
            }
        }

        public string Application_method
        {
            get
            {
                return application_method;
            }

            set
            {
                application_method = value;
            }
        }

        public string Family_members
        {
            get
            {
                return family_members;
            }

            set
            {
                family_members = value;
            }
        }

        public string Family_relationship
        {
            get
            {
                return family_relationship;
            }

            set
            {
                family_relationship = value;
            }
        }

        public string Family_occupation
        {
            get
            {
                return family_occupation;
            }

            set
            {
                family_occupation = value;
            }
        }

        public string Family_company
        {
            get
            {
                return family_company;
            }

            set
            {
                family_company = value;
            }
        }

        public string Family_contact1
        {
            get
            {
                return family_contact;
            }

            set
            {
                family_contact = value;
            }
        }

        public string Entry_unit
        {
            get
            {
                return entry_unit;
            }

            set
            {
                entry_unit = value;
            }
        }

        public string Entry_department
        {
            get
            {
                return entry_department;
            }

            set
            {
                entry_department = value;
            }
        }

        public string Entry_position
        {
            get
            {
                return entry_position;
            }

            set
            {
                entry_position = value;
            }
        }

        public string Leader
        {
            get
            {
                return leader;
            }

            set
            {
                leader = value;
            }
        }

        public string Part_time_job
        {
            get
            {
                return part_time_job;
            }

            set
            {
                part_time_job = value;
            }
        }

        public string Part_time_position
        {
            get
            {
                return part_time_position;
            }

            set
            {
                part_time_position = value;
            }
        }

        public string Branch_manager
        {
            get
            {
                return branch_manager;
            }

            set
            {
                branch_manager = value;
            }
        }

        public string Site_manager
        {
            get
            {
                return site_manager;
            }

            set
            {
                site_manager = value;
            }
        }

        public string Hr_clerk
        {
            get
            {
                return hr_clerk;
            }

            set
            {
                hr_clerk = value;
            }
        }

        public string Hr_manager
        {
            get
            {
                return hr_manager;
            }

            set
            {
                hr_manager = value;
            }
        }

        public string General_manager
        {
            get
            {
                return general_manager;
            }

            set
            {
                general_manager = value;
            }
        }

        public string Login_name
        {
            get
            {
                return login_name;
            }

            set
            {
                login_name = value;
            }
        }

        public string Access_authority
        {
            get
            {
                return access_authority;
            }

            set
            {
                access_authority = value;
            }
        }

        public string Account
        {
            get
            {
                return account;
            }

            set
            {
                account = value;
            }
        }

        public string Landscape
        {
            get
            {
                return landscape;
            }

            set
            {
                landscape = value;
            }
        }
    }
}


