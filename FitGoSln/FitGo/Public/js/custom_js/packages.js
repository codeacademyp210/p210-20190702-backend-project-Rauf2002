"use strict";
$(document).ready(function() {
    $('.datetimepicker6').datetimepicker({

        keepOpen: false,
        useCurrent: false,
        minDate: new Date().setHours(0, 0, 0, 0)
    });
    var date = new Date();
    date.setDate(date.getDate() - 1);
    $('.datetimepicker6').datetimepicker({
        startDate: date
    });

    $('.datetimepicker7').datetimepicker({

        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });

    $('.datetimepicker6').on("dp.change", function(e) {
        $('.datetimepicker7').data("DateTimePicker").minDate(e.date);
        $('#packages').bootstrapValidator('revalidateField', 'date_start');
    });

    $('.datetimepicker7').on("dp.change", function(e) {
        $('.datetimepicker6').data("DateTimePicker").maxDate(e.date);
        $('#packages').bootstrapValidator('revalidateField', 'date_end');

    });

    function validateEditor() {
        // Revalidate the content when its value is changed by Summernote
        $('#packages').bootstrapValidator('revalidateField', 'content');
    }
    $('#packages')
        .bootstrapValidator({
            excluded: [':disabled'],

            fields: {
                title: {
                    validators: {
                        notEmpty: {
                            message: 'The Package name is required and cannot be empty'
                        }
                    }
                },
                date_start: {
                    validators: {
                        notEmpty: {
                            message: 'The start date is required and cannot be empty'
                        }
                    }
                },
                date_end: {
                    validators: {
                        notEmpty: {
                            message: 'The end date is required and cannot be empty'
                        }

                    }
                },
                content: {
                    validators: {
                        callback: {
                            message: 'The content is required and cannot be empty',
                            callback: function(value, validator) {
                                var code = $('[name="content"]').code();
                                // <p><br></p> is code generated by Summernote for empty content
                                return (code !== '' && code !== '<p><br></p>');
                            }
                        }
                    }
                }
            }
        }).on('success.form.bv', function(e) {
            e.preventDefault();
            swal({
                title: "Success.",
                text: "Successfully Submitted",
                type: "success",
                allowOutsideClick: false

            }).then(function() {
                window.location.href = "packages.html";
            });
        }).on('summernote.change', function() {
            validateEditor();
            $('#packages').bootstrapValidator('revalidateField', 'content');
        })
        .find('[name="content"]').summernote({
            height: 200
        });
    $('input[type=reset]').on('click', function() {
        $(".note-editable").empty();
        $('#packages').bootstrapValidator("resetForm");
    });

    function row(fTable, frow) {
        var fData = fTable.fnGetData(frow);
        var ftable = $('>td', frow);
        for (var i = 0, iLen = ftable.length; i < iLen; i++) {
            fTable.fnUpdate(fData[i], frow, i, false);
        }
        fTable.fnDraw();
    }

    function editRow(fTable, frow) {
        var fData = fTable.fnGetData(frow);
        var ftable = $('>td', frow);
        ftable[0].innerHTML = '<input type="text" class="form-control input-small" value="' + fData[0] + '">';
        ftable[1].innerHTML = '<input type="text" class="form-control input-small" value="' + fData[1] + '">';
        ftable[2].innerHTML = '<input type="text" class="form-control input-small" value="' + fData[2] + '">';
        ftable[3].innerHTML = '<input type="text" class="form-control input-small" value="' + fData[3] + '">';
        ftable[4].innerHTML = '<a class="edit btn btn-success mar-bm" href="">Save</a>';
        ftable[5].innerHTML = '<a class="cancel btn btn-danger mar-bm" href="">Cancel</a>';
    }

    function saveRow(fTable, frow) {
        var jqInputs = $('input', frow);
        fTable.fnUpdate(jqInputs[0].value, frow, 0, false);
        fTable.fnUpdate(jqInputs[1].value, frow, 1, false);
        fTable.fnUpdate(jqInputs[2].value, frow, 2, false);
        fTable.fnUpdate(jqInputs[3].value, frow, 3, false);
        fTable.fnUpdate('<a class="edit btn btn-primary mar-bm" href=""><i class="fa fa-fw fa-edit"></i> Edit</a>', frow, 4, false);
        fTable.fnUpdate('<a class="delete btn btn-danger mar-bm" href=""><i class="fa fa-trash-o"></i> Delete</a>', frow, 5, false);
        fTable.fnDraw();
    }

    function cancelfitnessEditRow(fTable, frow) {
        var jqInputs = $('input', frow);
        fTable.fnUpdate(jqInputs[0].value, frow, 0, false);
        fTable.fnUpdate(jqInputs[1].value, frow, 1, false);
        fTable.fnUpdate(jqInputs[2].value, frow, 2, false);
        fTable.fnUpdate(jqInputs[3].value, frow, 3, false);
        fTable.fnUpdate('<a class="edit btn btn-primary mar-bm" href=""><i class="fa fa-fw fa-edit"></i>    Edit</a>', frow, 4, false);
        fTable.fnDraw();
    }
    var table = $('.table1');
    var fTable = table.dataTable({
        "lengthMenu": [
            [5, 15, 20, -1],
            [5, 15, 20, "All"]
        ],
        // set the initial value
        "pageLength": 5
    });
    var FitnessEditing = null;
    var FitnesNew = false;
    $('#table_new').click(function(e) {
        e.preventDefault();
        if (FitnesNew && FitnessEditing) {

            fTable.fnDeleteRow(FitnessEditing);
            FitnessEditing = null;
            FitnesNew = false;
            return;
        }
        var aiNew = fTable.fnAddData(['', '', '', '', '', '']);
        var frow = fTable.fnGetNodes(aiNew[0]);
        editRow(fTable, frow);
        FitnessEditing = frow;
        FitnesNew = true;
    });
    table.on('click', '.delete', function(e) {
        e.preventDefault();
        var frow = $(this).parent().parent('tr')[0];
        swal({
            title: "Delete?",
            text: "Are you sure want to delete this row",
            type: "warning",
            showCancelButton: true,
            confirmButtonText: "Yes",
            confirmButtonColor: "#33a4d8",
            cancelButtonColor: "#fc7070",
            cancelButtonText: "No",
            closeOnConfirm: false,
            closeOnCancel: false

        }).then(function () {
            fTable.fnDeleteRow(frow);
        });

    });
    table.on('click', '.cancel', function(e) {
        e.preventDefault();

        if (FitnesNew) {
            fTable.fnDeleteRow(FitnessEditing);
            FitnesNew = false;
        } else {
            row(fTable, FitnessEditing);
            FitnessEditing = null;
        }
    });
    table.on('click', '.edit', function(e) {
        e.preventDefault();
        var frow = $(this).parents('tr')[0];
        if (FitnessEditing !== null && FitnessEditing != frow) {
            row(fTable, FitnessEditing);
            editRow(fTable, frow);
            FitnessEditing = frow;
        } else if (FitnessEditing == frow && this.innerHTML == "Save") {
            saveRow(fTable, FitnessEditing);
            FitnessEditing = null;
            swal({
                title: "Updated.",
                text: "Successfully Saved",
                type: "success",
                allowOutsideClick: false
            })
        } else {
            editRow(fTable, frow);
            FitnessEditing = frow;
        }
    });
    //validaion
    $('#datetimepicker6').datetimepicker({

        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });
    var date = new Date();
    date.setDate(date.getDate() - 1);
    $('#datetimepicker6').datetimepicker({
        startDate: date
    });
    $('#datetimepicker7').datetimepicker({
        keepOpen: false,
        useCurrent: false,
        minDate: new Date()
    });
    $('#datetimepicker6').on("dp.change", function(e) {
        $('#datetimepicker7').data("DateTimePicker").minDate(e.date);
        $('#courseschedule_form').bootstrapValidator('revalidateField', 'time_from');
    });

    $('#datetimepicker7').on("dp.change", function(e) {
        $('#datetimepicker6').data("DateTimePicker").maxDate(e.date);
        $('#courseschedule_form').bootstrapValidator('revalidateField', 'time_to');

    });
});
