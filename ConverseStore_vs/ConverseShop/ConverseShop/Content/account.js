function thaydoidangnhap(pay) {
    var registerBtn = document.getElementById('dangnhap');
    var loginBtn = document.getElementById('dangki');

    if (registerBtn.style.display !== 'none') {
        registerBtn.style.display = 'none';
        loginBtn.style.display = 'block';
    } else {
        registerBtn.style.display = 'block';
        loginBtn.style.display = 'none';
    }
    // Ẩn tất cả các phần thông tin
    for (let i = 1; i <= 2; i++) {
        document.getElementById('infor' + i).style.display = 'none';
    }

    // Hiển thị phần thông tin tương ứng với menuNumber
    document.getElementById('infor' + pay).style.display = 'block'
}

