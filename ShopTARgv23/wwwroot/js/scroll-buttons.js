const scrollContainer = document.querySelector('.secondary-buttons');
const scrollLeft = document.querySelector('.nav-scroll-left');
const scrollRight = document.querySelector('.nav-scroll-right');

scrollLeft.addEventListener('click', () => {
    scrollContainer.scrollBy({ left: -200, behavior: 'smooth' });
});

scrollRight.addEventListener('click', () => {
    scrollContainer.scrollBy({ left: 200, behavior: 'smooth' });
});
