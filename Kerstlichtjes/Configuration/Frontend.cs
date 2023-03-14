namespace Kerstlichtjes.Configuration
{
    public static class Frontend
    {
        public const string Value = @"<!DOCTYPE html>
<html>
<title>
    Kerstlichtjes
</title>
<script>
    var xhr = new XMLHttpRequest();
    host = 'http://' + window.location.host;

    xhr.onreadystatechange = () => {
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            on = xhr.responseText === 'on';
            document.getElementById('status').style.color = on ? 'darkgreen' : 'white';
        }
    }

    function set(on) {
        url = on ? host + '/on' : host + '/off';
        xhr.open('POST', url);
        xhr.send();
    }
</script>

<body>
    <div>
        <span id='status' style='color: lightgray;'>&#9679;</span>
        <button onclick='set(true);'>On</button>
        <button onclick='set(false);'>Off</button>
    </div>
    <span style='position: absolute; bottom: 0px; font-family: Arial, Helvetica, sans-serif'>
        <a href='https://github.com/koent/kerstlichtjes' target='_blank' rel='noopener noreferrer'>
            Kerstlichtjes version 2 on GitHub
        </a>
    </span>
</body>

</html>";
    }
}