const handleConvertNumberToMoney = (number, ext = "") => {
    var formatNumber = number.toLocaleString('it-IT', { style: 'currency', currency: 'VND' });
    var formatNumberOnly = formatNumber.split("VND").shift();
    return `${formatNumberOnly} ${ext}`;
}