document.addEventListener('DOMContentLoaded', () => {
    fetchProducts();
});

function fetchProducts() {
    fetch('/api/products')
        .then(response => response.json())
        .then(products => {
            const wrapper = document.querySelector('.swiper-wrapper');
            wrapper.innerHTML = '';

            products.forEach(product => {
                wrapper.innerHTML += `
                    <div class="swiper-slide">
                        <div class="product-card">
                            <img id="product-img-${product.name}" src="${product.images.yellow}" class="product-img" alt="${product.name}">
                            <h4>${product.name}</h4>
                            <p class="price">$${product.price.toFixed(2)} <span class="currency">USD</span></p>
                            <div class="color-picker">
                                <button class="yellow" onclick="changeColor('${product.name}', '${product.images.yellow}', 'Yellow Gold', event)"></button>
                                <button class="white" onclick="changeColor('${product.name}', '${product.images.white}', 'White Gold', event)"></button>
                                <button class="rose" onclick="changeColor('${product.name}', '${product.images.rose}', 'Rose Gold', event)"></button>
                            </div>
                            <p class="color-name" id="color-name-${product.name}">Yellow Gold</p>
                            <div class="stars">
                                ${generateStars((product.popularityScore * 5).toFixed(1))}
                                <span style="font-family: 'Montserrat', sans-serif; font-weight: 500; margin-left: 5px; color: #000;">
                                    ${(product.popularityScore * 5).toFixed(1)}/5
                                </span>
                            </div>
                        </div>
                    </div>
                `;
            });

            new Swiper('.swiper-container', {
                slidesPerView: 4,
                spaceBetween: 20,
                loop: false,
                navigation: {
                    nextEl: '.swiper-button-next',
                    prevEl: '.swiper-button-prev',
                },
                breakpoints: {
                    1024: { slidesPerView: 4 },
                    768: { slidesPerView: 2 },
                    320: { slidesPerView: 1 },
                }
            });
        });
}

function changeColor(productName, imageUrl, colorName, event) {
    document.getElementById(`product-img-${productName}`).src = imageUrl;
    document.getElementById(`color-name-${productName}`).innerText = colorName;

    document.querySelectorAll(`#color-picker-${productName} button`).forEach(btn => {
        btn.classList.remove('selected');
    });

    event.target.classList.add('selected');
}

function generateStars(score) {
    const percentage = (score / 5) * 100;

    return `
        <div class="star-rating">
            <div class="star-rating__fill" style="width: ${percentage}%;">
                ★★★★★
            </div>
            <div class="star-rating__base">
                ★★★★★
            </div>
        </div>
    `;
}
