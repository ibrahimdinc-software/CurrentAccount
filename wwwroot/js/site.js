// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(function () {
    $.fn.serializeObject = function () {
        var o = {};
        var a = this.serializeArray();
        $.each(a, function () {
            if (o[this.name]) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                o[this.name] = this.value || '';
            }
        });
        return JSON.stringify(o);
        };
})


function getKayitliHesaplar() {
    var kayitliHesaplar = null
        $.ajax({
        url: '/Home/CariHesapListe',
        type: 'POST',
        contentType: "application/x-www-form-urlencoded; charset=utf-8",
        async: false,
        success: function (response) {
            if (response.status == "error") {
                kayitliHesaplar = 'Kayıt bulunamadı.'
                return
            }
            kayitliHesaplar = response.data
        }
    })
    return kayitliHesaplar
}