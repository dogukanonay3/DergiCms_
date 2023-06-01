function OnDergiDegisti() {
    var seciliDergiId = $('#DergiId').val();
    $("#SayiId").empty();

    $.ajax({
        type: "GET",
        url: "/Admin/Makale/SayiListele/" + seciliDergiId,
        success: function (data) {
            $.each(data, function (val, sayi) {
                $('#SayiId').append(
                    $('<option></option>').val(sayi.id).html(sayi.no)
                );
            });
        },
        error: function (req, status, error) {
            console.log(msg);
        }
    });
}
