var adminID = document.getElementById('adminID').value;
                        $(function () {

                            var url = '/api/Admin/';
                            url += adminID;
            $.ajax({
                type: 'GET',
                url: url,
                success: function (data) {

                    var imePrezime = document.getElementById('adminIme');
                    var emailPrikaz = document.getElementById('adminEmail');

                    imePrezime.innerHTML = data.ime + " " + data.prezime;
                    emailPrikaz.innerHTML = data.email;
                },
                error: function (error) {
                    alert('failed');
                }
            })


        }
            )