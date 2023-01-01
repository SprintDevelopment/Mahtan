$((function () {
    var url;
    var redirectUrl;

    $('body').append(`
            <div class="modal fade" id="deleteModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
                <div class="modal-dialog" role="document">
                    <div class="modal-content">
			            <div class="text-center">
				            <div class="w-100 py-4">
					            <i class="ci-close-circle text-danger" style="font-size: 3rem"></i>
				            </div>						
                            <p>آیا از حذف <span id="deleted-item-title" class="fw-bold"></span> اطمینان دارید ؟</p>
			            </div>
			            <div class="modal-footer border-0">
                            <button type="button" class="btn btn-sm btn-default btn-secondary" data-bs-dismiss="modal" id="cancel-delete">نه، حذف نشود</button>
                            <a class="btn btn-sm btn-danger" id="confirm-delete">بله، حذف شود</a>
			            </div>
                    </div>
                </div>
            </div>`);

    //Delete Action
    $("#data-list").on('click', '.delete', (e) => {
        e.preventDefault();

        var id = $(e.target).attr('data-id');
        var title = $(e.target).attr('data-title');
        
        $("#confirm-delete").attr('href', window.location.href + "/delete/" + id);
        $("#confirm-delete").on('click', (s) => {
            s.preventDefault();
            try {
                $.ajax({
                    async: true,
                    url: $(s.target).attr('href'),
                    contentType: false,
                    processData: false,
                    success: function (res) {
                        if (res.isValid) {
                            $("#data-list").html(res.html);
                            $("#deleteModal").modal('hide');
                        }
                    }
                })
            } catch (e) {
                console.log(e);
            }
            return false;
        });
        $('#deleted-item-title').text(title);
        $("#deleteModal").modal('show');
    });

    $("#deleteModal").on('hidden.bs.modal', function (e) {
        e.preventDefault();
    });
}()));