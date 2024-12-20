using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HR_2024.Core.Model
{
    public class Employee_Data
    {
       //*****************البيانات الشخصية
        public int Id { get; set; }//inc
       // public int FNO { get; set; }//fno
        public int employee_num { get; set; }//no
        public string national_num { get; set; }//rw
        public string fullName { get; set; }//nam
        public string motherName { get; set; }//mnam
        public int gender { get; set; }//se
        public DateTime birthDate { get; set; }//bdt
        public int birthPlace { get; set; }//bpl
        public int nationality { get; set; }//nat
        public int work_location { get; set; } //plase
        public int sotial_situation { get; set; }//stat
        public int numb_Children { get; set; }//cno
        public int identificationCardNum { get; set; }//id
        public int issuance_place_id { get; set; }//idpl
        public DateTime date_issuance_id { get; set; }//did
        public string passport_num { get; set; }//pass

        public int issuance_place_passport { get; set; }//ppl

        public DateTime date_issuance_passport { get; set; }//dpl
        public string familyRegistNum { get; set; }//kno

        public int issuance_place_familyRegis { get; set; }//pkno

        public int ID_num { get; set; }//hno

        public int familyPaperNum { get; set; }//rno

        public int guaranteeNum { get; set; }//dno
        public string address { get; set; }//adr
        public string phone_num { get; set; }//tel
        //**********************************************end البيانات الشخصية

        //*************************البيانات الادارية
        //  public int qualification { get; set; }//moa

        //public int specialization { get; set; }//note

        //public int specialization_type { get; set; }//note1

        //public int qualification_Type { get; set; }//flg

        //public string qualification_source { get; set; }//smoa
        //public DateTime qualification_date { get; set; }//dmoa
        public List<Staff_qualification> staff_Qualification { get; set; } = new List<Staff_qualification>();
  

        public int unqualificated { get; set; }//nmoa

        public int current_job { get; set; }//jop


        public string character { get; set; }//sta

        public int num_Member_desicion { get; set; }//no_o
        public DateTime Date_decision { get; set; }//date_no
        public int staffing { get; set; }//m_j

        public int delegate_job { get; set; }//jop1
    

        public int vacation_balance { get; set; }//ras_rst
        public DateTime until_date { get; set; }//DT_RST


        public int period_saved_vacation { get; set; }//dur_ejaza

        public int num_saved_decision { get; set; }//no_krar_ejaza
        public DateTime date_saved_decision { get; set; }//date_ejaza
      //  public string MG { get; set; }
        public string current_status { get; set; }//NSTA
        public string career_status { get; set; }//wsta

        public int num_decision { get; set; }//no_k
        public DateTime date_of_decision { get; set; }//date_k
        public DateTime date_from { get; set; }//date_s
        public DateTime date_to { get; set; }//date_e
        public int reasons_for_resignation { get; set; }//res
        public DateTime date_resignation { get; set; }//date_res

        public int retirement_type { get; set; }//pur
        public int place_displacement { get; set; }//plase_nazah



        //*************5/12/2024
        //public int generalmanagement { get; set; }//lv
        //public int management_sub { get; set; }
        //public int department { get; set; }
        public int generalmanagementid { get; set; }//lv
        public int management_subid { get; set; }
        public int departmentid { get; set; }
        public GeneralManagement generalManagement { get; set; }
        public Management_Sub management_sub { get; set; }
        public Department department { get; set; }
        
        //*****************end 5/12/2024

        public DateTime date_start_work { get; set; }//SDT
        public DateTime appointment_date { get; set; }//TDT
        public DateTime joining_date { get; set; }//LTDT
        public DateTime date_period_from { get; set; }//d_date1
        public DateTime date_period_to { get; set; }//d_date2
        public int period_add { get; set; }//dur_d
        public DateTime num_add_decision { get; set; }//no_krar_d
        public DateTime date_last_contract { get; set; }//date_krar_d
        public int num_appointment_decision {  get; set; }//no_t
        public DateTime date_appointment_decision { get; set; }//tds

        //بيانات العقد
        public DateTime contract_start_date { get; set; }//ddate_s
        public DateTime contract_end_date { get; set; }//ddate_e
        public int contract_period { get; set; }//dp
        //*********end بيانات العقد

        public byte flag_m {  get; set; }//flag_m
        public int assigned_from { get; set; } //cfor
        public int assigned_to { get; set; }//cfor1
        public int delegation_decission_num { get; set; }//no_nd

        public DateTime delegation_date_from { get; set; }//nddt
        public DateTime delegation_date_to { get; set; }//enddt
     //*******************************end البيانات الادارية

        //*****************البيانات المالية 
        public int bank {  get; set; }//bank
        public int bank_branch { get; set; }
        public string account_number { get; set; }//ano
        public string account_number_new { get; set; }//anon
        public byte mr {  get; set; }//mr
        public DateTime mr_date { get; set; }//dmr
        public int jop_grade { get; set; }//mar
        public DateTime jop_grade_date { get; set; }//dmar

        public int degree_assigned_to { get; set; }//nmr
        public DateTime degree_assigned_to_date { get; set; }//dnmr
        public int jop_position_grade_num { get; set; }//m_no
        public int degree_appointment { get; set; }//tmar
        public int bonus { get; set; }//ala

        public DateTime bonus_month { get; set; }//minc

        public int salary_type { get; set; }//sry
        public decimal basic_salary { get; set; }//sar

        public DateTime joining_date_fund  {  get; set; }//ndt
        public int receipt_number { get; set; }//sno
        public int num_year_extend { get; set; }//year_no

//ترقية تشجيعية وعلاوة تشجيعية وعقوبة ورقم القرار المفروض لاتخزن في جدول الموظفين وانما يتم جلبها من جداولها التي تخزن فيها




        //********************end  البيانات المالية


    }
}
