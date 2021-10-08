var korisnikID = document.getElementById('korisnikID').value;
                        $(function () {

                            var url = '/api/Korisnik/';
                            url += korisnikID;
            $.ajax({
                type: 'GET',
                url: url,
                success: function (data) {

                    var imePrezime = document.getElementById('korisnikIme');
                    var emailPrikaz = document.getElementById('korisnikEmail');

                    imePrezime.innerHTML = data.ime + " " + data.prezime;
                    emailPrikaz.innerHTML = data.email;
                },
                error: function (error) {
                    alert('failed');
                }
            })


        }
            )