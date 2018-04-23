Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.XtraReports.Design
Imports DevExpress.XtraReports.UserDesigner
Imports EUD_AddDataSource.nwindDataSetTableAdapters
' ...

Namespace EUD_AddDataSource
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Private ds As New nwindDataSet()
		Private adapter As New ProductsTableAdapter()

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) _
		Handles button1.Click
			' Create an End-User Designer form.
			Dim form As New XRDesignFormEx()

			' Create a report instance.
			Dim report As New XtraReport1()

			' Add data components to the Designer Host.
			AddHandler form.DesignPanel.DesignerHostLoaded, _
			AddressOf OnDesignerLoaded

			' Load the report into the End-User Designer.
			form.OpenReport(report)

			' Bind the report to data.
			report.DataSource = ds
			report.DataAdapter = adapter
			report.DataMember = "Products"

			' Show the End-User Designer form.
			form.ShowDialog()
		End Sub

		Private Sub OnDesignerLoaded(ByVal sender As Object, ByVal e As DesignerLoadedEventArgs)
			ReportDesigner.AddToContainer(e.DesignerHost, ds)
			ReportDesigner.AddToContainer(e.DesignerHost, adapter)
		End Sub

	End Class

End Namespace