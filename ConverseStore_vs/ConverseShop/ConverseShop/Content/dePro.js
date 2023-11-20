


function showInfo(menuNumber) {

    for (let i = 1; i <= 4; i++) {
        document.getElementById('info' + i).style.display = 'none';
    }
    document.getElementById('info' + menuNumber).style.display = 'block';


}

// console.log(amount);

function showInfo(menuNumber) {

    for (let i = 1; i <= 4; i++) {
        document.getElementById('info' + i).style.display = 'none';
    }
    document.getElementById('info' + menuNumber).style.display = 'block';

    document.getElementById(menuNumber === '1' ? '2' : '1').style = "";
    document.getElementById(menuNumber).style.background = "#8e9392";
    document.getElementById(menuNumber).style.color = "black";

    document.getElementById(menuNumber === '2' ? '3' : '2').style = "";
    document.getElementById(menuNumber).style.background = "#8e9392";
    document.getElementById(menuNumber).style.color = "black";

    document.getElementById(menuNumber === '3' ? '4' : '3').style = "";
    document.getElementById(menuNumber).style.background = "#8e9392";
    document.getElementById(menuNumber).style.color = "black";

    document.getElementById(menuNumber === '3' ? '4' : '4').style = "";
    document.getElementById(menuNumber).style.background = "#8e9392";
    document.getElementById(menuNumber).style.color = "black";





}
// slide show sản phẩm

// 
function show(so) {

    for (let i = 1; i <= 3; i++) {
        document.getElementById('anh' + i).style.display = 'none';
    }
    document.getElementById('anh' + so).style.display = 'block';


}

// Mở thanh đăng nhập
// const openCart = document.querySelector('.js-openCart');
// const closeCart = document.querySelector('.cart__header-close');
// const modalCart = document.querySelector('.modal__cart');
// const modalProduct = document.querySelector('.modal__cart-container');
// openCart.addEventListener('click',() => {
//   modalCart.classList.add('active-cover');
// })
// closeCart.addEventListener('click',() => {
//   modalCart.classList.remove('active-cover')
// })
// // modalCart.addEventListener('click',() => {
// //   modalCart.classList.remove('active-cover')
// // })
// modalProduct.addEventListener('click', (event) => {
//   event.stopPropagation();
// })

//Phần hình ảnh

document.addEventListener("DOMContentLoaded", function () {
    const slides = document.querySelector(".img-mini");
    const prevBtn = document.getElementById("downButton");
    const nextBtn = document.getElementById("upButton");
    let currentIndex = 0;

    function showSlides() {
        slides.style.transform = `translateY(${-currentIndex * 23}%)`;
    }

    function nextSlide() {
        if (currentIndex < 3) {
            currentIndex++;
            showSlides();
        }
    }

    function prevSlide() {
        if (currentIndex > 0) {
            currentIndex--;
            showSlides();
        }
    }

    nextBtn.addEventListener("click", nextSlide);
    prevBtn.addEventListener("click", prevSlide);
});
var swiper = new Swiper('.swiper-container', {
    // các tùy chọn khác...
    slidesPerView: 2,  // Điều chỉnh giá trị này
    slidesPerGroup: 2, // Điều chỉnh giá trị này
    // các tùy chọn khác...
});


 
