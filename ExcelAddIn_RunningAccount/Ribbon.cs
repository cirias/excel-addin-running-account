/************************************** 插件主画面 **************************************
 * 项目名称：MS Excel 2010 财务插件
 * 功能描述：创建并打开导航画面、导航画面中的功能的实现。
 * 创 建 人：方慧聪
 ****************************************************************************************
 */
/* =================================== 版本更新履历 =====================================
 * 更新日期		  更新人		                  更新内容
 * --------------------------------------------------------------------------------------
 * ======================================================================================
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools;
using CtpLibrary;
using Microsoft.Office.Interop.Excel;
using System.Diagnostics;

//TODO: 按照以下步骤启用功能区(XML)项:

// 1. 将以下代码块复制到 ThisAddin、ThisWorkbook 或 ThisDocument 类中。

//  protected override Microsoft.Office.Core.IRibbonExtensibility CreateRibbonExtensibilityObject()
//  {
//      return new Ribbon();
//  }

// 2. 在此类的“功能区回调”区域中创建回调方法，以处理用户
//    操作(如单击某个按钮)。注意: 如果已经从功能区设计器中导出此功能区，
//    则将事件处理程序中的代码移动到回调方法并修改该代码以用于
//    功能区扩展性(RibbonX)编程模型。

// 3. 向功能区 XML 文件中的控制标记分配特性，以标识代码中的相应回调方法。

// 有关详细信息，请参见 Visual Studio Tools for Office 帮助中的功能区 XML 文档。


namespace ExcelAddIn_RunningAccount
{
    [ComVisible(true)]
    public class Ribbon : Office.IRibbonExtensibility
    {
        private Office.IRibbonUI ribbon;

        private Dictionary<string, CustomTaskPane> dicTaskPanes = new Dictionary<string, CustomTaskPane>();//已创建的导航画面集合

        public static CustomTaskPaneCollection taskPaneCollection;                                 //导航画面集合

        public static Application applicationObject;                                               //Excel的Application对象

        public Ribbon()
        {
        }

        public void Button_Click(Office.IRibbonControl control)
        {
            //根据控件ID载入相应导航画面
            switch (control.Id)
            {
                #region/*InitializeModel 初始化模板*/
                case "btnInitializeModel":
                    {
                        applicationObject.ScreenUpdating = false;                                  //禁止屏幕刷新
                        //applicationObject.Calculation = XlCalculation.xlCalculationManual;         //设置手动计算

                        //applicationObject.ActiveWorkbook.Sheets.Delete();
                        //Worksheet ws = applicationObject.ActiveWorkbook.Sheets.Add();

                        //保证至少有3张Sheet
                        while (applicationObject.ActiveWorkbook.Sheets.Count < 5)
                        {
                            applicationObject.ActiveWorkbook.Sheets.Add();
                        }

                        //设置Sheet名字
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets[1]).Name = "账户信息";
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets[2]).Name = "支出类型";
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets[3]).Name = "收入类型";
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets[4]).Name = "收支记录";
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets[5]).Name = "转账记录";

                        #region/*账户类型*/

                        Range rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A1", Type.Missing);
                        rng.Value = "账户类型";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A1:B1", Type.Missing);
                        rng.Merge();

                        #region/*一级目录*/

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A2", Type.Missing);
                        rng.Value = "现金账户";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A3", Type.Missing);
                        rng.Value = "银行账户";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A3:A5", Type.Missing);
                        rng.Merge();

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A6", Type.Missing);
                        rng.Value = "虚拟账户";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A6:A8", Type.Missing);
                        rng.Merge();

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A9", Type.Missing);
                        rng.Value = "负债";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A9:A10", Type.Missing);
                        rng.Merge();

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("A11", Type.Missing);
                        rng.Value = "债权";

                        #endregion

                        #region/*二级目录*/

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B2", Type.Missing);
                        rng.Value = "现金账户";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B3", Type.Missing);
                        rng.Value = "储蓄卡/借记卡";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B4", Type.Missing);
                        rng.Value = "存折";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B5", Type.Missing);
                        rng.Value = "理财产品";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B6", Type.Missing);
                        rng.Value = "在线支付";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B7", Type.Missing);
                        rng.Value = "现金券";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B8", Type.Missing);
                        rng.Value = "储值卡";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B9", Type.Missing);
                        rng.Value = "信用卡";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B10", Type.Missing);
                        rng.Value = "应付款项";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("B11", Type.Missing);
                        rng.Value = "应收款项";

                        #endregion

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("C1", Type.Missing);
                        rng.Value = "账户名称";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("D1", Type.Missing);
                        rng.Value = "初始金额";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).Columns[4, Type.Missing];
                        rng.NumberFormatLocal = "￥#,##0.00;[红色]-￥#,##0.00";                     //设置显示样式

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("E1", Type.Missing);
                        rng.Value = "账户余额";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).Columns[5, Type.Missing];
                        rng.NumberFormatLocal = "￥#,##0.00;[红色]-￥#,##0.00";                     //设置显示样式

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("H1", Type.Missing);
                        rng.FormulaArray = "=IFERROR(OFFSET($C$1,SMALL(IF($C$1:$C$100<>0,ROW($C$1:$C$100),\"\"),ROW(H1))-1,0),1)";
                        rng.AutoFill(((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("H1:H15"));
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).get_Range("H1:H100").Calculate();

                        #endregion

                        #region/*支出类型*/

                        Worksheet wsExpenseType = (Worksheet)applicationObject.ActiveWorkbook.Sheets["支出类型"];
                        ((Range)wsExpenseType.get_Range("A1")).Value = "衣服饰品";
                        ((Range)wsExpenseType.get_Range("B1")).Value = "食品酒水";
                        ((Range)wsExpenseType.get_Range("C1")).Value = "居家物业";
                        ((Range)wsExpenseType.get_Range("D1")).Value = "行车交通";
                        ((Range)wsExpenseType.get_Range("E1")).Value = "交流通讯";
                        ((Range)wsExpenseType.get_Range("F1")).Value = "休闲娱乐";
                        ((Range)wsExpenseType.get_Range("G1")).Value = "人情往来";
                        ((Range)wsExpenseType.get_Range("H1")).Value = "自我投资";
                        ((Range)wsExpenseType.get_Range("I1")).Value = "耐用投资";
                        ((Range)wsExpenseType.get_Range("J1")).Value = "医疗保健";
                        ((Range)wsExpenseType.get_Range("K1")).Value = "金融保险";
                        ((Range)wsExpenseType.get_Range("L1")).Value = "其他杂项";

                        ((Range)wsExpenseType.get_Range("A2")).Value = "衣裤";
                        ((Range)wsExpenseType.get_Range("A3")).Value = "鞋帽包包";
                        ((Range)wsExpenseType.get_Range("A4")).Value = "饰品";

                        ((Range)wsExpenseType.get_Range("B2")).Value = "早晚午餐";
                        ((Range)wsExpenseType.get_Range("B3")).Value = "烟酒茶";
                        ((Range)wsExpenseType.get_Range("B4")).Value = "水果零食";

                        ((Range)wsExpenseType.get_Range("C2")).Value = "日常用品";
                        ((Range)wsExpenseType.get_Range("C3")).Value = "水电煤";
                        ((Range)wsExpenseType.get_Range("C4")).Value = "房租";
                        ((Range)wsExpenseType.get_Range("C5")).Value = "物业管理";
                        ((Range)wsExpenseType.get_Range("C6")).Value = "维修保养";

                        ((Range)wsExpenseType.get_Range("D2")).Value = "公共交通";
                        ((Range)wsExpenseType.get_Range("D3")).Value = "出租车";
                        ((Range)wsExpenseType.get_Range("D4")).Value = "私家车";

                        ((Range)wsExpenseType.get_Range("E2")).Value = "座机费";
                        ((Range)wsExpenseType.get_Range("E3")).Value = "手机费";
                        ((Range)wsExpenseType.get_Range("E4")).Value = "上网费";
                        ((Range)wsExpenseType.get_Range("E5")).Value = "邮寄费";

                        ((Range)wsExpenseType.get_Range("F2")).Value = "运动";
                        ((Range)wsExpenseType.get_Range("F3")).Value = "腐败聚会";
                        ((Range)wsExpenseType.get_Range("F4")).Value = "宠物";
                        ((Range)wsExpenseType.get_Range("F5")).Value = "旅游";
                        ((Range)wsExpenseType.get_Range("F6")).Value = "休闲玩乐";
                        ((Range)wsExpenseType.get_Range("F7")).Value = "小说杂志";

                        ((Range)wsExpenseType.get_Range("G2")).Value = "请客送礼";
                        ((Range)wsExpenseType.get_Range("G3")).Value = "孝敬家长";
                        ((Range)wsExpenseType.get_Range("G4")).Value = "还钱（出）";
                        ((Range)wsExpenseType.get_Range("G5")).Value = "借钱（出）";
                        ((Range)wsExpenseType.get_Range("G6")).Value = "慈善";

                        ((Range)wsExpenseType.get_Range("H2")).Value = "书籍";
                        ((Range)wsExpenseType.get_Range("H3")).Value = "培训";
                        ((Range)wsExpenseType.get_Range("H4")).Value = "美容";

                        ((Range)wsExpenseType.get_Range("I2")).Value = "家具";
                        ((Range)wsExpenseType.get_Range("I3")).Value = "电器";
                        ((Range)wsExpenseType.get_Range("I4")).Value = "数码";

                        ((Range)wsExpenseType.get_Range("J2")).Value = "药品费";
                        ((Range)wsExpenseType.get_Range("J3")).Value = "保健费";
                        ((Range)wsExpenseType.get_Range("J4")).Value = "治疗费";

                        ((Range)wsExpenseType.get_Range("K2")).Value = "银行手续";
                        ((Range)wsExpenseType.get_Range("K3")).Value = "投资亏损";
                        ((Range)wsExpenseType.get_Range("K4")).Value = "按揭还款";
                        ((Range)wsExpenseType.get_Range("K5")).Value = "消费税收";
                        ((Range)wsExpenseType.get_Range("K6")).Value = "利息支出";
                        ((Range)wsExpenseType.get_Range("K7")).Value = "保险支出";

                        ((Range)wsExpenseType.get_Range("L2")).Value = "赔偿罚金";
                        ((Range)wsExpenseType.get_Range("L3")).Value = "意外丢失";
                        ((Range)wsExpenseType.get_Range("L4")).Value = "烂账损失";

                        #endregion

                        #region/*收入类型*/

                        Worksheet wsIncomeType = (Worksheet)applicationObject.ActiveWorkbook.Sheets["收入类型"];
                        ((Range)wsIncomeType.get_Range("A1")).Value = "工资";
                        ((Range)wsIncomeType.get_Range("B1")).Value = "利息";
                        ((Range)wsIncomeType.get_Range("C1")).Value = "投资";
                        ((Range)wsIncomeType.get_Range("D1")).Value = "经营";
                        ((Range)wsIncomeType.get_Range("E1")).Value = "还款（进）";
                        ((Range)wsIncomeType.get_Range("F1")).Value = "借款（进）";

                        #endregion

                        #region/*记录头*/

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("D1", Type.Missing);
                        rng.Value = "衣服饰品";

                        //支出子类 数据有效性设置
                        string strColumnEValidationFormula = @"=OFFSET(支出类型!$A$2,,MATCH($D1,支出类型!$1:$1,)-1,COUNTA(OFFSET(支出类型!$A$2,,MATCH($D1,支出类型!$1:$1,)-1,65535)))";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("E:E");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlNotBetween, strColumnEValidationFormula, Type.Missing);
                        rng.Validation.InCellDropdown = true;
                        rng.Validation.IgnoreBlank = true;

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("A1", Type.Missing);
                        rng.Value = "日期";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).Columns[1, Type.Missing];
                        rng.NumberFormatLocal = "yyyy\"年\"m\"月\"d\"日\"";                        //设置显示样式

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("B1", Type.Missing);
                        rng.Value = "名称";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("C1", Type.Missing);
                        rng.Value = "金额";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).Columns[3, Type.Missing];
                        rng.NumberFormatLocal = "￥#,##0.00;[红色]-￥#,##0.00";                     //设置显示样式

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("D1", Type.Missing);
                        rng.Value = "总类";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("E1", Type.Missing);
                        rng.Value = "子类";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("F1", Type.Missing);
                        rng.Value = "收入类型";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("G1", Type.Missing);
                        rng.Value = "账户";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("H1", Type.Missing);
                        rng.Value = "余额";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).Columns[8, Type.Missing];
                        rng.NumberFormatLocal = "￥#,##0.00;[红色]-￥#,##0.00";                     //设置显示样式

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("I1", Type.Missing);
                        rng.Value = "收支总和";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("J1", Type.Missing);
                        rng.Value = "出账总和";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("K1", Type.Missing);
                        rng.Value = "进账总和";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("L1", Type.Missing);
                        rng.Value = "初始金额";

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("I1:L1");
                        rng.ColumnWidth = 0;

                        //rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("H1", Type.Missing);
                        //rng.Value = "人员";

                        //设置筛选
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("1:1", Type.Missing);
                        rng.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);

                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).Activate();        //激活“收支记录表”

                        //冻结表头
                        applicationObject.ActiveWindow.SplitRow = 1;
                        applicationObject.ActiveWindow.FreezePanes = true;

                        //支出总类 数据有效性设置
                        string strColumnDValidationFormula = "=OFFSET(支出类型!$A$1,0,0,1,COUNTA(支出类型!$1:$1))";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("D:D");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlNotBetween, strColumnDValidationFormula, Type.Missing);
                        rng.Validation.InCellDropdown = true;
                        rng.Validation.IgnoreBlank = true;

                        //收入类型 数据有效性设置
                        string strColumnFValidationFormula = "=OFFSET(收入类型!$A$1,0,0,1,COUNTA(收入类型!$1:$1))";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("F:F");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlNotBetween, strColumnFValidationFormula, Type.Missing);
                        rng.Validation.InCellDropdown = true;
                        rng.Validation.IgnoreBlank = true;

                        //日期 数据有效性设置
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("A:A");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateDate, Type.Missing, XlFormatConditionOperator.xlNotEqual, "1900-1-1");
                        rng.Validation.IgnoreBlank = true;

                        //金额 数据有效性设置
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("C:C");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateDecimal, Type.Missing, XlFormatConditionOperator.xlNotEqual, "0");
                        rng.Validation.IgnoreBlank = true;

                        //账户 数据有效性设置
                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").Value = "Meow";
                        string strColumnGValidationFormula = "=OFFSET(账户信息!$H$1,1,0,COUNTA(账户信息!$H$1:$H$65536)-COUNTIF(账户信息!$H$1:$H$65536,\"1\")-1,1)";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("G:G");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlNotBetween, strColumnGValidationFormula, Type.Missing);
                        rng.Validation.InCellDropdown = true;
                        rng.Validation.IgnoreBlank = true;

                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").Value = null;
                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").FormulaArray = "=IFERROR(OFFSET($C$1,SMALL(IF($C$1:$C$100<>0,ROW($C$1:$C$100),\"\"),ROW(H2))-1,0),1)";
                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").Calculate();

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("I:I");
                        //rng.Formula
                        //rng.FormulaArray = "=SUM(IF(INDIRECT(\"收支记录!R2C7:R\"&SUM(ROW())&\"C7\",FALSE)=INDIRECT(\"收支记录!R\"&SUM(ROW())&\"C7\",FALSE),INDIRECT(\"收支记录!R2C3:R\"&SUM(ROW())&\"C3\",FALSE),0),-IF((转账记录!R2C3:R65536C3=INDIRECT(\"收支记录!R\"&SUM(ROW())&\"C7\",FALSE))*(转账记录!R2C1:R65536C1<=INDIRECT(\"收支记录!R\"&SUM(ROW())&\"C1\",FALSE)),转账记录!R2C2:R65536C2,0),IF((转账记录!R2C4:R65536C4=INDIRECT(\"收支记录!R\"&SUM(ROW())&\"C7\",FALSE))*(转账记录!R2C1:R65536C1<=INDIRECT(\"收支记录!R\"&SUM(ROW())&\"C1\",FALSE)),转账记录!R2C2:R65536C2,0),IF(账户信息!R2C3:R65536C3=INDIRECT(\"收支记录!R\"&SUM(ROW())&\"C7\",FALSE),账户信息!R2C4:R65536C4,0))";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).get_Range("H1", Type.Missing);
                        rng.Value = "余额";
                        #endregion

                        #region/*转账记录*/

                        Worksheet wsTransferRecord = (Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"];
                        rng = wsTransferRecord.get_Range("A1");
                        rng.Value = "日期";
                        rng = wsTransferRecord.Columns[1];
                        rng.NumberFormatLocal = "yyyy\"年\"m\"月\"d\"日\"";

                        rng = wsTransferRecord.get_Range("B1");
                        rng.Value = "金额";
                        rng = wsTransferRecord.Columns[2];
                        rng.NumberFormatLocal = "￥#,##0.00;[红色]-￥#,##0.00";

                        rng = wsTransferRecord.get_Range("C1");
                        rng.Value = "转出账户";

                        rng = wsTransferRecord.get_Range("D1");
                        rng.Value = "转入账户";

                        //账户 数据有效性设置
                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").Value = "Meow";
                        string strAccountValidationFormula = "=OFFSET(账户信息!$H$1,1,0,COUNTA(账户信息!$H$1:$H$65536)-COUNTIF(账户信息!$H$1:$H$65536,\"1\")-1,1)";
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"]).get_Range("$C:$C");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlNotBetween, strAccountValidationFormula, Type.Missing);
                        rng.Validation.InCellDropdown = true;
                        rng.Validation.IgnoreBlank = true;

                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"]).get_Range("$E:$E");
                        rng.Validation.Delete();
                        rng.Validation.Add(XlDVType.xlValidateList, XlDVAlertStyle.xlValidAlertStop, XlFormatConditionOperator.xlNotBetween, strAccountValidationFormula, Type.Missing);
                        rng.Validation.InCellDropdown = true;
                        rng.Validation.IgnoreBlank = true;

                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"]).get_Range("$D:$D").Delete();
                        wsTransferRecord.get_Range("D1").Value = "转入账户";

                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").Value = null;
                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").FormulaArray = "=IFERROR(OFFSET($C$1,SMALL(IF($C$1:$C$100<>0,ROW($C$1:$C$100),\"\"),ROW(H2))-1,0),1)";
                        ((Worksheet)applicationObject.Worksheets["账户信息"]).get_Range("H2").Calculate();

                        //设置筛选
                        rng = ((Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"]).get_Range("1:1", Type.Missing);
                        rng.AutoFilter(1, Type.Missing, XlAutoFilterOperator.xlAnd, Type.Missing, true);

                        //冻结表头
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"]).Activate();        //激活“转账记录表”
                        applicationObject.ActiveWindow.SplitRow = 1;
                        applicationObject.ActiveWindow.FreezePanes = true;

                        #endregion

                        //设置"账户信息"Sheet、"收支类型"Sheet深度隐藏
                        //((Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"]).Visible = XlSheetVisibility.xlSheetVeryHidden;
                        //((Worksheet)applicationObject.ActiveWorkbook.Sheets["支出类型"]).Visible = XlSheetVisibility.xlSheetVeryHidden;
                        //((Worksheet)applicationObject.ActiveWorkbook.Sheets["收入类型"]).Visible = XlSheetVisibility.xlSheetVeryHidden;
                        ((Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"]).Activate();        //激活“收支记录表”
                        applicationObject.ScreenUpdating = true;

                        break;
                    }
                #endregion

                #region/*AddPayment 添加收支记录*/
                case "btnAddPayment":
                    {
                        CustomTaskPane ctpAddPayment = null;                                       //声明导航画面

                        //尝试从已新建的导航画面集合中查找该画面
                        if (dicTaskPanes.TryGetValue("btnAddPayment", out ctpAddPayment))
                        {
                            ctpAddPayment.Visible = true;
                        }
                        else
                        {
                            #region/*从Excel表格读取画面数据*/

                            #region/*读取支出类型*/

                            Worksheet wsExpenseType = (Worksheet)applicationObject.ActiveWorkbook.Sheets["支出类型"];
                            Dictionary<string, List<string>> DicExpenseTypes = new Dictionary<string, List<string>>();//存放支出类型的数据对象
                            Range rngFirstCell = ((Range)wsExpenseType.get_Range("A1"));

                            try
                            {
                                do
                                {
                                    List<string> lstExpenseType = new List<string>();
                                    Range rngSecondCell = wsExpenseType.Cells[rngFirstCell.Row + 1, rngFirstCell.Column];

                                    do
                                    {
                                        lstExpenseType.Add(rngSecondCell.Value);
                                        rngSecondCell = wsExpenseType.Cells[rngSecondCell.Row + 1, rngSecondCell.Column];
                                    }
                                    while (rngSecondCell.Value != null);

                                    DicExpenseTypes.Add(rngFirstCell.Value, lstExpenseType);
                                    rngFirstCell = rngFirstCell.Next;
                                }
                                while (rngFirstCell != null);
                            }
                            catch
                            {
                                //MessageBox.Show("工作簿非法！");
                            }

                            #endregion

                            #region/*读取收入类型*/

                            Worksheet wsIncomeType = (Worksheet)applicationObject.ActiveWorkbook.Sheets["收入类型"];
                            rngFirstCell = ((Range)wsIncomeType.get_Range("A1"));
                            List<string> lstIncomeTypes = new List<string>();//存放收入类型的数据对象

                            try
                            {
                                do
                                {
                                    lstIncomeTypes.Add(rngFirstCell.Value);
                                    rngFirstCell = rngFirstCell.Next;
                                }
                                while (rngFirstCell.Value != null);
                            }
                            catch
                            {
                                //MessageBox.Show("工作簿非法！");
                            }

                            #endregion

                            #region/*读取账户名称*/

                            Worksheet wsAccountInfo = (Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"];//获取“账户信息”Worksheet
                            Range rngAccountInfo = wsAccountInfo.get_Range("A1", "Z1000");         //搜索范围
                            Range rngAccountNameTile = rngAccountInfo.Find("账户名称", Type.Missing,//获取内容为“账户名称”的单元格
                                                                            XlFindLookIn.xlValues, XlLookAt.xlPart,
                                                                            XlSearchOrder.xlByRows, XlSearchDirection.xlNext,
                                                                            false, Type.Missing, Type.Missing);
                            int intRowNum = wsAccountInfo.Range[rngAccountNameTile.Address.Substring(0, rngAccountNameTile.Address.LastIndexOf('$')) + "$65536"].End[XlDirection.xlUp].Row;//“账户名称”列最后非单元格的行号
                            List<string> lstAccountNames = new List<string>();                     //存放账户名称的数据对象

                            //循环获取账户名称
                            for (int i = rngAccountNameTile.Row + 1; i <= intRowNum; i++)
                            {
                                Range rngAccountName = wsAccountInfo.get_Range(rngAccountNameTile.Address.Substring(0, rngAccountNameTile.Address.LastIndexOf('$')) + "$" + i.ToString());

                                //若单元格内容非空，则添加该单元格内容到账户名称数据对象
                                if (rngAccountName.Value != null)
                                {
                                    lstAccountNames.Add(rngAccountName.Value);
                                }
                            }

                            #endregion

                            #endregion

                            //创建导航画面
                            try
                            {
                                var ctpNewAddPayment = new CtpAddPayment(DicExpenseTypes, lstIncomeTypes, lstAccountNames);
                                ctpNewAddPayment.AddPaymentEventHandler += new EventHandler<AddPaymentEventArgs>(CtpAddPayment_AddPaymentEvent);//载入导航画面按钮事件
                                var ctpCurrentPane = taskPaneCollection.Add(ctpNewAddPayment, "记一笔");
                                ctpCurrentPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionLeft;
                                ctpCurrentPane.Width = 212;
                                ctpCurrentPane.Visible = true;

                                dicTaskPanes.Add("btnAddPayment", ctpCurrentPane);
                            }
                            catch (COMException ex)
                            {
                                Console.WriteLine("Create CTP encounter errors: " + ex.ToString());
                            }
                        }

                        break;
                    }
                #endregion

                #region/*AccountManage 账户管理*/
                case "btnAccountManage":
                    {
                        CustomTaskPane ctpAccountManage = null;

                        if (dicTaskPanes.TryGetValue("btnAccountManage", out ctpAccountManage))
                        {
                            ctpAccountManage.Visible = true;
                        }
                        else
                        {
                            Worksheet wsAccountInfo = (Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"];
                            Range rngAccountInfo = wsAccountInfo.get_Range("A1", "Z1000");

                            #region/*读取账户类型*/

                            Range rngAccountTypeTitle = rngAccountInfo.Find("账户类型", Type.Missing,
                                                                            XlFindLookIn.xlValues, XlLookAt.xlPart,
                                                                            XlSearchOrder.xlByRows, XlSearchDirection.xlNext,
                                                                            false, Type.Missing, Type.Missing);
                            int intAccountTypeTitleCol = rngAccountTypeTitle.Column;
                            int intAccountTypeTitleRow = rngAccountTypeTitle.Row;

                            Range rngFirstAccountType = wsAccountInfo.Cells[intAccountTypeTitleRow + 1, intAccountTypeTitleCol];
                            Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>> dicAccountTypes = new Dictionary<string, Dictionary<string, Dictionary<string, dynamic>>>();

                            while (rngFirstAccountType.Next.Next.Value != null || rngFirstAccountType.Next.Value != null)
                            {
                                string strFirstAccountType = rngFirstAccountType.Value;
                                Dictionary<string, Dictionary<string, dynamic>> dicAccountSecondType = new Dictionary<string, Dictionary<string, dynamic>>();

                                do
                                {
                                    string strSecondAccountType = rngFirstAccountType.Next.Value;
                                    Dictionary<string, dynamic> dicAccountNameAndMoney = new Dictionary<string, dynamic>();

                                    if (rngFirstAccountType.Next.Value != null && rngFirstAccountType.Next.Next.Value == null)
                                    {
                                        dicAccountSecondType.Add(strSecondAccountType, null);
                                        rngFirstAccountType = wsAccountInfo.Cells[rngFirstAccountType.Row + 1, rngFirstAccountType.Column];

                                        continue;
                                    }

                                    do
                                    {
                                        dicAccountNameAndMoney.Add(rngFirstAccountType.Next.Next.Value, rngFirstAccountType.Next.Next.Next.Value);
                                        rngFirstAccountType = wsAccountInfo.Cells[rngFirstAccountType.Row + 1, rngFirstAccountType.Column];
                                    }
                                    while (rngFirstAccountType.Next.Value == null && rngFirstAccountType.Next.Next.Value != null);

                                    dicAccountSecondType.Add(strSecondAccountType, dicAccountNameAndMoney);
                                }
                                while (rngFirstAccountType.Value == null && rngFirstAccountType.Next.Value != null);

                                dicAccountTypes.Add(strFirstAccountType, dicAccountSecondType);
                            }

                            #endregion

                            try
                            {
                                var ctpNewAccountManage = new CtpAccountManage(dicAccountTypes);
                                ctpNewAccountManage.AddAccountEventHandler += new EventHandler<AddAccountEventArgs>(CtpAccountManage_AddAccountEvent);
                                ctpNewAccountManage.DeleteAccountEventHandler += new EventHandler<DeleteAccountEventArgs>(CtpAccountManage_DeleteAccountEvent);
                                var ctpCurrentPane = taskPaneCollection.Add(ctpNewAccountManage, "账户管理");
                                ctpCurrentPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionLeft;
                                ctpCurrentPane.Width = 235;
                                ctpCurrentPane.Visible = true;

                                dicTaskPanes.Add("btnAccountManage", ctpCurrentPane);
                            }
                            catch (COMException ex)
                            {
                                Console.WriteLine("Create CTP encounter errors: " + ex.ToString());
                            }
                        }

                        break;
                    }
                #endregion

                #region/*AddTransfer 添加转账记录*/
                case "btnAddTransfer":
                    {
                        CustomTaskPane ctpAddTransfer = null;

                        if (dicTaskPanes.TryGetValue("btnAddTransfer", out ctpAddTransfer))
                        {
                            ctpAddTransfer.Visible = true;
                        }
                        else
                        {
                            Worksheet wsAccountInfo = (Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"];
                            int intLastNotEmptyRow = wsAccountInfo.Range["$A$65536"].End[XlDirection.xlUp].Row;
                            List<string> lstAccountNames = new List<string>();

                            for (int i = 2; i <= intLastNotEmptyRow; i++)
                            {
                                if (wsAccountInfo.get_Range("C" + i.ToString()).Value != null)
                                {
                                    lstAccountNames.Add(wsAccountInfo.get_Range("C" + i.ToString()).Value);
                                }
                            }

                            try
                            {
                                var ctpNewAddTransfer = new CtpAddTransfer(lstAccountNames);
                                ctpNewAddTransfer.AddTransferEventHandler += new EventHandler<AddTransferEventArgs>(CtpAddTransfer_AddTransferEvent);
                                var ctpCurrentPane = taskPaneCollection.Add(ctpNewAddTransfer, "记录转账");
                                ctpCurrentPane.DockPosition = Office.MsoCTPDockPosition.msoCTPDockPositionLeft;
                                ctpCurrentPane.Width = 235;
                                ctpCurrentPane.Visible = true;

                                dicTaskPanes.Add("btnAddTransfer", ctpCurrentPane);
                            }
                            catch (COMException ex)
                            {
                                Console.WriteLine("Create CTP encounter errors: " + ex.ToString());
                            }
                        }

                        break;
                    }
                #endregion

                #region/*CalculateBalances 计算余额*/
                case "btnCalculateBalances":
                    {
                        applicationObject.ActiveCell.EntireRow.Calculate();

                        break;
                    }
                #endregion
            }
        }

        /// <summary>
        /// 添加账户事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtpAccountManage_AddAccountEvent(object sender, AddAccountEventArgs e)
        {
            applicationObject.ScreenUpdating = false;

            Worksheet wsAccountInfo = (Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"];
            Range rngAccountInfo = wsAccountInfo.get_Range("A1", "Z1000");
            Range rngFirstAccountType = rngAccountInfo.Find(e.StrFirstAccountType, Type.Missing,
                                                            XlFindLookIn.xlValues, XlLookAt.xlPart,
                                                            XlSearchOrder.xlByRows, XlSearchDirection.xlNext,
                                                            false, Type.Missing, Type.Missing);
            Range rngNewFirstAccountType = rngFirstAccountType;
            Range rngSecondAccountType = rngFirstAccountType.MergeArea.EntireRow.Find(e.StrSecondAccountType, Type.Missing,
                                                            XlFindLookIn.xlValues, XlLookAt.xlPart,
                                                            XlSearchOrder.xlByColumns, XlSearchDirection.xlNext,
                                                            false, Type.Missing, Type.Missing);
            Range rngNewSecondAccountType = rngSecondAccountType;
            Range rngCurrent = rngFirstAccountType.MergeArea.EntireRow.FindNext(rngSecondAccountType);
            Range rngFoundFirst = null;
            char[] separator = { '$', ':' };

            while (rngCurrent != null)
            {
                if (rngFoundFirst == null)
                {
                    rngFoundFirst = rngCurrent;
                }
                else if (rngCurrent.get_Address() == rngFoundFirst.get_Address())
                {
                    break;
                }
                rngSecondAccountType = rngCurrent;
                rngCurrent = rngFirstAccountType.MergeArea.EntireRow.FindNext(rngSecondAccountType);
            }

            if (rngSecondAccountType.Next.Value != null)
            {
                if (rngFirstAccountType.Next.Value == rngSecondAccountType.Value)
                {
                    rngSecondAccountType.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown);
                    string[] arrStrAddressOfFirstAccountType = rngFirstAccountType.Address.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                    if (arrStrAddressOfFirstAccountType.Length == 4)
                    {
                        rngNewFirstAccountType = wsAccountInfo.get_Range("$" + arrStrAddressOfFirstAccountType[0] + "$" + (Convert.ToInt16(arrStrAddressOfFirstAccountType[1]) - 1) + ":$" + arrStrAddressOfFirstAccountType[2] + "$" + arrStrAddressOfFirstAccountType[3]);
                    }
                    else if (arrStrAddressOfFirstAccountType.Length == 2)
                    {
                        rngNewFirstAccountType = wsAccountInfo.get_Range("$" + arrStrAddressOfFirstAccountType[0] + "$" + (Convert.ToInt16(arrStrAddressOfFirstAccountType[1]) - 1) + ":$" + arrStrAddressOfFirstAccountType[0] + "$" + arrStrAddressOfFirstAccountType[1]);
                    }

                    rngNewFirstAccountType.Merge();
                }
                else
                {
                    rngSecondAccountType.EntireRow.Insert(XlInsertShiftDirection.xlShiftDown);
                }

                string[] arrStrAddressOfSecondAccountType = rngSecondAccountType.Address.Split(separator, StringSplitOptions.RemoveEmptyEntries);

                if (arrStrAddressOfSecondAccountType.Length == 4)
                {
                    rngNewSecondAccountType = wsAccountInfo.get_Range("$" + arrStrAddressOfSecondAccountType[0] + "$" + (Convert.ToInt16(arrStrAddressOfSecondAccountType[1]) - 1) + ":$" + arrStrAddressOfSecondAccountType[2] + "$" + arrStrAddressOfSecondAccountType[3]);
                }
                else if (arrStrAddressOfSecondAccountType.Length == 2)
                {
                    rngNewSecondAccountType = wsAccountInfo.get_Range("$" + arrStrAddressOfSecondAccountType[0] + "$" + (Convert.ToInt16(arrStrAddressOfSecondAccountType[1]) - 1) + ":$" + arrStrAddressOfSecondAccountType[0] + "$" + arrStrAddressOfSecondAccountType[1]);
                }

                rngNewSecondAccountType.Merge();
            }

            string strFormulaArray = "=SUM(IF(收支记录!$G$1:$G$65536=账户信息!" + rngNewSecondAccountType.Next.Address
                                        + ",收支记录!$C$1:$C$65536,0),-IF(转账记录!$C$1:$C$65536=账户信息!" + rngNewSecondAccountType.Next.Address
                                        + ",转账记录!$B$1:$B$65536,0),IF(转账记录!$D$1:$D$65536=账户信息!" + rngNewSecondAccountType.Next.Address
                                        + ",转账记录!$B$1:$B$65536,0),账户信息!" + rngNewSecondAccountType.Next.Next.Address
                                        + ")";
            rngNewSecondAccountType.Next.Value = e.StrName;
            rngNewSecondAccountType.Next.Next.Value = e.DblMoney;
            rngNewSecondAccountType.Next.Next.Next.FormulaArray = strFormulaArray;
            wsAccountInfo.get_Range("H1").AutoFill(wsAccountInfo.get_Range("H1:H15"));
            wsAccountInfo.get_Range("H1:H100").Calculate();

            applicationObject.ScreenUpdating = true;
        }

        /// <summary>
        /// 删除账户事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtpAccountManage_DeleteAccountEvent(object sender, DeleteAccountEventArgs e)
        {
            applicationObject.ScreenUpdating = false;

            Worksheet wsAccountInfo = (Worksheet)applicationObject.ActiveWorkbook.Sheets["账户信息"];
            Range rngAccountInfo = wsAccountInfo.get_Range("A1", "Z1000");
            Range rngFirstAccountType = rngAccountInfo.Find(e.StrFirstAccountType, Type.Missing,
                                                            XlFindLookIn.xlValues, XlLookAt.xlPart,
                                                            XlSearchOrder.xlByRows, XlSearchDirection.xlNext,
                                                            false, Type.Missing, Type.Missing);
            Range rngNewFirstAccountType = null;
            Range rngSecondAccountType = rngFirstAccountType.MergeArea.EntireRow.Find(e.StrSecondAccountType, Type.Missing,
                                                            XlFindLookIn.xlValues, XlLookAt.xlPart,
                                                            XlSearchOrder.xlByColumns, XlSearchDirection.xlNext,
                                                            false, Type.Missing, Type.Missing);
            Range rngNewSecondAccountType = null;
            Range rngCurrent = rngFirstAccountType.MergeArea.EntireRow.FindNext(rngSecondAccountType);
            Range rngFoundFirst = null;
            Range rngAccountNames = null;
            Range rngAccountName = null;
            char[] separator = { '$', ':' };

            while (rngCurrent != null)
            {
                if (rngFoundFirst == null)
                {
                    rngFoundFirst = rngCurrent;
                }
                else if (rngCurrent.get_Address() == rngFoundFirst.get_Address())
                {
                    break;
                }
                rngSecondAccountType = rngCurrent;
                rngCurrent = rngFirstAccountType.MergeArea.EntireRow.FindNext(rngSecondAccountType);
            }

            string[] arrStrAddressOfSecondAccountType = rngSecondAccountType.MergeArea.Address.Split(separator, StringSplitOptions.RemoveEmptyEntries);

            if (arrStrAddressOfSecondAccountType.Length == 4)
            {
                rngAccountNames = wsAccountInfo.get_Range("$" + (char)((short)arrStrAddressOfSecondAccountType[0].ToCharArray()[0] + 1) + "$" + arrStrAddressOfSecondAccountType[1] + ":$" + (char)((short)arrStrAddressOfSecondAccountType[2].ToCharArray()[0] + 1) + "$" + arrStrAddressOfSecondAccountType[3]);
                rngAccountName = rngAccountNames.Find(e.StrName, Type.Missing,
                                                        XlFindLookIn.xlValues, XlLookAt.xlWhole,
                                                        XlSearchOrder.xlByColumns, XlSearchDirection.xlNext,
                                                        false, Type.Missing, Type.Missing);
                if (rngFirstAccountType.Row == rngSecondAccountType.Row && rngSecondAccountType.Row == rngAccountName.Row)
                {
                    rngNewFirstAccountType = wsAccountInfo.Cells[rngFirstAccountType.Row + 1, rngFirstAccountType.Column];
                    rngNewSecondAccountType = wsAccountInfo.Cells[rngSecondAccountType.Row + 1, rngSecondAccountType.Column];
                    rngAccountName.EntireRow.Delete();
                    rngNewFirstAccountType.Value = e.StrFirstAccountType;
                    rngNewSecondAccountType.Value = e.StrSecondAccountType;
                }
                else if (rngSecondAccountType.Row == rngAccountName.Row)
                {
                    rngNewSecondAccountType = wsAccountInfo.Cells[rngSecondAccountType.Row + 1, rngSecondAccountType.Column];
                    rngAccountName.EntireRow.Delete();
                    rngNewSecondAccountType.Value = e.StrSecondAccountType;
                }
                else
                {
                    rngAccountName.EntireRow.Delete();
                }
            }
            else if (arrStrAddressOfSecondAccountType.Length == 2)
            {
                rngSecondAccountType.Next.Value = null;
                rngSecondAccountType.Next.Next.Value = null;
                rngSecondAccountType.Next.Next.Next.Value = null;
            }

            wsAccountInfo.get_Range("H1:H100").Calculate();

            applicationObject.ScreenUpdating = true;
        }

        /// <summary>
        /// 添加收支记录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtpAddPayment_AddPaymentEvent(object sender, AddPaymentEventArgs e)
        {
            applicationObject.ScreenUpdating = false;
            Worksheet wsPaymentsRecords = (Worksheet)applicationObject.ActiveWorkbook.Sheets["收支记录"];
            int intLastNotEmptyRow = wsPaymentsRecords.Range["$A$65536"].End[XlDirection.xlUp].Row;
            Range rngDate = wsPaymentsRecords.Range["$A$" + (intLastNotEmptyRow + 1).ToString()];
            Range rngName = wsPaymentsRecords.Range["$B$" + (intLastNotEmptyRow + 1).ToString()];
            Range rngMoney = wsPaymentsRecords.Range["$C$" + (intLastNotEmptyRow + 1).ToString()];
            Range rngAccountName = wsPaymentsRecords.Range["$G$" + (intLastNotEmptyRow + 1).ToString()];
            Range rngBalance = wsPaymentsRecords.Range["$H$" + (intLastNotEmptyRow + 1).ToString()];

            if (e.IsExpense)
            {
                wsPaymentsRecords.Range["$D$" + (intLastNotEmptyRow + 1).ToString()].Value = e.FirstType;
                wsPaymentsRecords.Range["$E$" + (intLastNotEmptyRow + 1).ToString()].Value = e.SecondType;
            }
            else
            {
                wsPaymentsRecords.Range["$F$" + (intLastNotEmptyRow + 1).ToString()].Value = e.FirstType;
            }

            rngDate.Value = e.DateTime.Year.ToString() + "-" + e.DateTime.Month.ToString() + "-" + e.DateTime.Day.ToString();
            rngName.Value = e.Name;
            rngMoney.Value = e.Money;
            rngAccountName.Value = e.AccountName;

            ((Range)wsPaymentsRecords.Range["$I$" + (intLastNotEmptyRow + 1).ToString()]).FormulaArray = "=SUM(IF(INDIRECT(\"收支记录!$G$2:$G$\"&SUM(ROW()))=INDIRECT(\"收支记录!$G$\"&SUM(ROW())),INDIRECT(\"收支记录!$C$2:$C$\"&SUM(ROW())),0))";
            ((Range)wsPaymentsRecords.Range["$J$" + (intLastNotEmptyRow + 1).ToString()]).FormulaArray = "=SUM(-IF((转账记录!$C$2:$C$65536=INDIRECT(\"收支记录!$G$\"&SUM(ROW())))*(转账记录!$A$2:$A$65536<=INDIRECT(\"收支记录!$A$\"&SUM(ROW()))),转账记录!$B$2:$B$65536,0))";
            ((Range)wsPaymentsRecords.Range["$K$" + (intLastNotEmptyRow + 1).ToString()]).FormulaArray = "=SUM(IF((转账记录!$D$2:$D$65536=INDIRECT(\"收支记录!$G$\"&SUM(ROW())))*(转账记录!$A$2:$A$65536<=INDIRECT(\"收支记录!$A$\"&SUM(ROW()))),转账记录!$B$2:$B$65536,0))";
            ((Range)wsPaymentsRecords.Range["$L$" + (intLastNotEmptyRow + 1).ToString()]).FormulaArray = "=SUM(IF(账户信息!$C$2:$C$65536=INDIRECT(\"收支记录!$G$\"&SUM(ROW())),账户信息!$D$2:$D$65536,0))";
            rngBalance.Formula = "=SUM(INDIRECT(\"收支记录!$I$\"&ROW()&\":$L$\"&ROW()))";

            Range rng = wsPaymentsRecords.Range["A2:L65536"];
            rng.Sort(rng.Columns[1, Type.Missing],XlSortOrder.xlAscending);

            //rngBalance.FormulaArray = "=SUM("
            //    + "IF(INDIRECT(\"收支记录!$G$2:$G$\"&SUM(ROW()))=INDIRECT(\"收支记录!$G$\"&SUM(ROW())),INDIRECT(\"收支记录!$C$2:$C$\"&SUM(ROW())),0),"
            //    + "-IF((转账记录!$C$2:$C$65536=INDIRECT(\"收支记录!$G$\"&SUM(ROW())))*(转账记录!$A$2:$A$65536<=INDIRECT(\"收支记录!$A$\"&SUM(ROW()))),转账记录!$B$2:$B$65536,0),"
            //    + "IF((转账记录!$D$2:$D$65536=INDIRECT(\"收支记录!$G$\"&SUM(ROW())))*(转账记录!$A$2:$A$65536<=INDIRECT(\"收支记录!$A$\"&SUM(ROW()))),转账记录!$B$2:$B$65536,0),"
            //    + "IF(账户信息!$C$2:$C$65536=INDIRECT(\"收支记录!$G$\"&SUM(ROW())),账户信息!$D$2:$D$65536,0))";

            applicationObject.ScreenUpdating = true;
        }

        /// <summary>
        /// 添加转账记录事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtpAddTransfer_AddTransferEvent(object sender, AddTransferEventArgs e)
        {
            applicationObject.ScreenUpdating = false;

            Worksheet wsTransferRecords = (Worksheet)applicationObject.ActiveWorkbook.Sheets["转账记录"];
            int intFirstEmptyRow = wsTransferRecords.Range["$A$65536"].End[XlDirection.xlUp].Row + 1;
            wsTransferRecords.Range["$A$" + intFirstEmptyRow.ToString()].Value = e.DateTime.Year.ToString() + "-" + e.DateTime.Month.ToString() + "-" + e.DateTime.Day.ToString();
            wsTransferRecords.Range["$B$" + intFirstEmptyRow.ToString()].Value = e.Money;
            wsTransferRecords.Range["$C$" + intFirstEmptyRow.ToString()].Value = e.OutAccount;
            wsTransferRecords.Range["$D$" + intFirstEmptyRow.ToString()].Value = e.InAccount;

            applicationObject.ScreenUpdating = true;
        }

        #region IRibbonExtensibility 成员

        public string GetCustomUI(string ribbonID)
        {
            return GetResourceText("ExcelAddIn_RunningAccount.Ribbon.xml");
        }

        #endregion

        #region 功能区回调
        //在此创建回调方法。有关添加回调方法的详细信息，请在解决方案资源管理器中选择功能区 XML 项，然后按 F1

        public void Ribbon_Load(Office.IRibbonUI ribbonUI)
        {
            this.ribbon = ribbonUI;
        }

        #endregion

        #region 帮助器

        private static string GetResourceText(string resourceName)
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            string[] resourceNames = asm.GetManifestResourceNames();
            for (int i = 0; i < resourceNames.Length; ++i)
            {
                if (string.Compare(resourceName, resourceNames[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    using (StreamReader resourceReader = new StreamReader(asm.GetManifestResourceStream(resourceNames[i])))
                    {
                        if (resourceReader != null)
                        {
                            return resourceReader.ReadToEnd();
                        }
                    }
                }
            }
            return null;
        }

        #endregion
    }
}
