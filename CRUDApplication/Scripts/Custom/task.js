
$(document).ready(function () {
    loadData();
});

// Load Data.
function loadData() {
    $.ajax({
        url: "/api/task/gettasks",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            var j = jQuery.parseJSON(JSON.stringify(result));
            for (var i in j) {
                html += '<tr>';
                html += '<td>' + j[i].TaskId + '</td>';
                html += '<td>' + j[i].TaskName + '</td>';
                html += '<td>' + j[i].Priority + '</td>';
                html += '<td>' + FormatDate(j[i].TaskDate) + '</td>';
                html += '<td>' + j[i].EstimatedCost + '</td>';
                html += '<td>' + j[i].Description + '</td>';
                html += '<td><a href="javascript:void(0);" onclick="return getbyID(' + j[i].TaskId + ')">Edit</a> | <a href="javascript:void(0);" onclick="Delele(' + j[i].TaskId + ')">Delete</a></td>';
                html += '</tr>';
            }
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function FormatDate(taskDate)
{
    var dt = new Date(taskDate);
    var ret = dt.getFullYear() + "-" + dt.getMonth() + "-" + dt.getDate();
    return ret;
}

// Add Data.
function Add() {   
    var taskObject = {
        TaskName: $('#TaskName').val(),
        Priority: $('#Priority').val(),
        TaskDate: $('#TaskDate').val(),
        EstimatedCost: $('#EstimatedCost').val(),
        Description: $('#Description').val()
    };

    $.ajax({
        url: "/api/task/addtask",
        data: JSON.stringify(taskObject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#AddTaskPopup').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

// Delete Data
function Delele(TaskId) {
    var ans = confirm("Are you sure you want to delete this Task?");
    if (ans) {
        var dataValue = {
            taskID: TaskId
        };
        $.ajax({
            url: "/api/task/DeleteTask/" + TaskId,
            type: "POST",
            //data: JSON.stringify(dataValue),
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function ShowTaskPopup() {
    $("#AddTaskPopup").modal({
        backdrop: 'static',
        show: true
    });

    $('#TaskId').val("");
    $('#TaskName').val("");
    $('#TaskDate').val("");
    $('#EstimatedCost').val("");
    $('#Description').val("");
    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

// Get Data by ID
function getbyID(TaskId) {
    $.ajax({
        url: "/api/task/GetTask/" + TaskId,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#TaskId').val(result.TaskId);
            $('#TaskName').val(result.TaskName);

            $('#Priority').val(result.Priority);
            $('#TaskDate').val(FormatDate(result.TaskDate));
            $('#EstimatedCost').val(result.EstimatedCost);
            $('#Description').val(result.Description);
           
            $('#AddTaskPopup').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

// Update Data
function Update() {
    
    var taskObject = {
        TaskId: $('#TaskId').val(),
        TaskName: $('#TaskName').val(),
        Priority: $('#Priority').val(),
        TaskDate: $('#TaskDate').val(),
        EstimatedCost: $('#EstimatedCost').val(),
        Description: $('#Description').val()
    };

    $.ajax({
        url: "/api/task/EditTask",
        data: JSON.stringify(taskObject),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#AddTaskPopup').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}