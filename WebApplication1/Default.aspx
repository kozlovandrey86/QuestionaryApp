<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication1._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

      
    
    
     <form class="form-horizontal">
  <legend>Questionary</legend>
    <div class="control-group">
        <div class="controls">
        <input type="text" id="firstName" placeholder="First Name">
        </div>
        </div>
    <div class="control-group">
        <div class="controls">
        <input type="text" id="secondName" placeholder="Second Name">
             </div>
        </div>
            <div class="control-group">
        <div class="controls">
        <input type="text" id="birhtday" placeholder="Birhtday">
             </div>
        </div>
        <br/>
        <input type="button" id="add" value="Add"  class="btn btn-primary">
         </form>
   
        <div id="questionaryTable">
             <br/>
            <table border=1  class="table">
        <tr><th>First Name</th><th>Second Name</th><th>Birthday</th><th/><th/></tr>
        </table>
            </div>


  <div class="modal fade" id="edit" role="dialog">
    <div class="modal-dialog">
    
      <div class="modal-content">
          <input type="hidden" id="hdnid">
        <div class="modal-header">
          <button type="button" class="close" data-dismiss="modal">&times;</button>
          <h4 class="modal-title">Edit</h4>
        </div>
        <div class="modal-body">
            <form class="form-horizontal">
                <div class="control-group">
        <div class="controls">
                <input type="text" id="firstNameEdit">
               </div>
        </div>
            <div class="control-group">
        <div class="controls">
                <input type="text" id="secondNameEdit">
               </div>
        </div>
            <div class="control-group">
        <div class="controls">
                <input type="text" id="birhtdayEdit">
               </div>
        </div>
        </div>
        <div class="modal-footer">
          <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
          <button type="button" class="btn btn-default" data-dismiss="modal" id="save">Save</button>
        </div>
      </div>
      
    </div>
  </div>

    

<script type="text/javascript">

    $("#birhtday, #birhtdayEdit").datepicker();



    $("#add").click(function () {

        firstName = $('#firstName').val()
        secondName = $('#secondName').val()
        birhtday = $("#birhtday").datepicker("getDate")

        var questionary = { 'firstName': firstName, 'secondName': secondName, 'birhtday': birhtday };
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Default.aspx/Add",
            data: JSON.stringify(questionary),
            datatype: "json",
            success: function (result) {
                addQuestionary(questionary, result.d);
            },
            error: function () {
                alert(" error ")
            }
        });
    })

    $(function () {
        $.ajax({
            type: "GET",
            contentType: "application/json; charset=utf-8",
            url: "Default.aspx/GetAll",

            datatype: "json",
            success: function (result) {
                fillQuestionaries(result);
            },
            error: function () {
                alert(" error ")
            }
        })
    })

    function addQuestionary(questionary, id) {

        var table = $("#questionaryTable table")[0]

        var row = $(table.insertRow(-1))

        row.append($("<td />").html(questionary.firstName))
        row.append($("<td />").html(questionary.secondName))

        var date = questionary.birhtday
        row.append($("<td />").html(date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear()))

        row.append($("<td><input class='btn btn-primary' type='button' value='Delete' data-questionaryid=" + id + " onclick=deletequestionary(" + id + ")></td>"))
        var params = id 
        row.append($("<td><input type='button' value='Edit' onclick=editquestionary(" + params + ") class='btn btn-primary' data-toggle='modal' data-target='#edit'></td>"))
        $("#questionaryTable").append(table)
    }

    function fillQuestionaries(response) {

        var table = $("#questionaryTable table")[0]
        var questionaries = response.d
        $("#questionaryTable table").eq(0).remove()
        $(questionaries).each(function () {
            var row = $(table.insertRow(-1))
            row.append($("<td />").html(this.FirstName))
            row.append($("<td />").html(this.SecondName))
            var date = new Date(parseInt(this.Birthday.substr(6)));
            row.append($("<td />").html(date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear()))
            row.append($("<td><input type='button' class='btn btn-primary' value='Delete' data-questionaryid=" + this.Id + " onclick=deletequestionary(" + this.Id + ")></td>"))
            var params = this.Id
            row.append($("<td><input type='button' value='Edit'  onclick = editquestionary(" + params + ")  class='btn btn-primary' data-toggle='modal' data-target='#edit'/></td>"))
        })
        $("#questionaryTable").append(table)
    }

    function deletequestionary(id) {

        $.ajax({
            type: "post",
            contentType: "application/json; charset=utf-8",
            url: "Default.aspx/Deleted",
            data: JSON.stringify({ 'id': id }),
            datatype: "json",
            success: function (result) {
                deletequestionaryfromtable(id)
            },
            error: function () {
                alert(" error ")
            }
        })
    }

    function deletequestionaryfromtable(id) {
        $("[data-questionaryid=" + id + "]").parent().parent().remove();
    }


    function editquestionary(id) {
        
        row = $("[data-questionaryid=" + id + "]").parent().parent()

        var tds = $('td', row)
        firstName = tds[0].innerText
        secondname = tds[1].innerText 
        date = tds[2].innerText.split('/')

        $("#firstNameEdit").val(firstName)
        $("#secondNameEdit").val(secondname)

        $("#birhtdayEdit").datepicker("setDate", new Date(date[2], date[1]-1, date[0]))
        $("#hdnid").val(id);
    }

    function editquestionaryfromtable(questionary) {
        var row = $("[data-questionaryid=" + questionary.id + "]").parent().parent();
        var tds = $('td', row)
        tds[0].innerText = questionary.firstName
        tds[1].innerText = questionary.secondName
        var date = questionary.birhtday
        tds[2].innerText = date.getDate() + "/" + (date.getMonth() + 1) + "/" + date.getFullYear()
    }

    $("#save").click(function () {

        firstName = $('#firstNameEdit').val()
        secondName = $('#secondNameEdit').val()
        birhtday = $("#birhtdayEdit").datepicker("getDate")
        id = $("#hdnid").val();

        var questionary = { 'id': id, 'firstName': firstName, 'secondName': secondName, 'birhtday': birhtday };
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Default.aspx/Edit",
            data: JSON.stringify(questionary),
            datatype: "json",
            success: function (result) {

                editquestionaryfromtable(questionary)
                
            },
            error: function () {
                alert("error")
            }
        });
    })


    </script>

</asp:Content>