var organizatorID = document.getElementById('organizatorID').value;
                        $(function () {

                            var url = '/api/Organizator/';
                            url += organizatorID;
            $.ajax({
                type: 'GET',
                url: url,
                success: function (data) {

                    var imePrezime = document.getElementById('organizatorIme');
                    var emailPrikaz = document.getElementById('organizatorEmail');

                    imePrezime.innerHTML = data.ime + " " + data.prezime;
                    emailPrikaz.innerHTML = data.email;
                },
                error: function (error) {
                    alert('failed');
                }
            })


        }
            )