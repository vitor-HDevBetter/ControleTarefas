

function OpenModalCriarEditarTarefa(codTarefa) {

    $.ajax({
        url: urlOpenModalCriarEditarTarefa,
        type: 'POST',
        data: { codTarefa },
    })
        .done(function (data) {

            $('#criar-editar-tarefa').html(data);
            $("#modalTarefa").modal('toggle');

        })
        .fail(function (jqXHR, textStatus, msg) {
        });
}

function CriarEditarTarefa() {

    debugger;

    var dados =
    {
        CodTarefa: $("#codTarefa").val(),
        Titulo: $("#txtTitulo").val(),
        Descricao: $("#txtDescricao").val(),
        CodTarefaPrioridade: $("#txtPrioridade").val(),
        CodTarefaStatus: $("#codTarefaStatus").val()
    }

    $.ajax({
        url: urlCriarEditarTarefa,
        type: 'POST',
        data: dados,
    })
        .done(function (data) {

            if (data.success == true) {

                $('#modalTarefa').modal('toggle');
                $("#retornoViewDefault").hide();
                $("#modalTarefa input, #modalTarefa textarea").val('');

                Swal.fire({
                    icon: 'success',
                    title: 'Feito',
                    text: 'Task criada com sucesso, a pagina será recarregada ... !',
                    allowOutsideClick: false,
                }).then((result) => {
                    if (result.isConfirmed) {
                        document.location.reload(true);
                    }
                });

                return;
            }

            $("#retornoViewDefault").html(data);

        })
        .fail(function (jqXHR, textStatus, msg) {
        });
}

function ObterDescricao(codTarefa) {

    $.ajax({
        url: urlObterDescricao,
        type: 'POST',
        data: { codTarefa },
    })
        .done(function (data) {

            $('#descricao-tarefa').html(data);
            $("#modalDescricao").modal('toggle');

        })
        .fail(function (jqXHR, textStatus, msg) {
        });
}

function Deletar(codTarefa) {

    Swal.fire({
        title: 'Olá',
        text: "Tem certeza que deseja deletar essa tarefa ?",
        icon: 'question',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Sim',
        cancelButtonText: 'Não'
    }).then((result) => {
        if (result.isConfirmed) {

            $.ajax({
                url: urlDeletar,
                type: 'POST',
                data: { codTarefa },
            })
                .done(function (data) {

                    if (data.success == true) {

                        Swal.fire({
                            icon: 'success',
                            title: 'Feito',
                            text: 'Tarefa deletada com sucesso, a pagina será recarregada ... !',
                            allowOutsideClick: false,
                        }).then((result) => {
                            if (result.isConfirmed) {
                                document.location.reload(true);
                            }
                        });
                    }
                    else {

                        Swal.fire({
                            icon: 'error',
                            title: 'Olá',
                            text: data.msg
                        })
                    }
                })
                .fail(function (jqXHR, textStatus, msg) {
                });
        }
    })
}

function MudarStatus(codTarefa, status) {

    $.ajax({
        url: urlMudarStatus,
        type: 'POST',
        data: { codTarefa, status },
    })
        .done(function (data) {

            if (data.success == true) {

                Swal.fire({
                    icon: 'success',
                    title: 'Feito',
                    text: 'Status alterado com sucesso ... !',
                    allowOutsideClick: false,
                }).then((result) => {
                    if (result.isConfirmed) {
                        document.location.reload(true);
                    }
                });
            }
            else {
                Swal.fire({
                    icon: 'error',
                    title: 'Olá',
                    text: data.msg
                })
            }
        })
        .fail(function (jqXHR, textStatus, msg) {
        });
}
