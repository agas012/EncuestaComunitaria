window.getClickPosition = (element, clientX, clientY) => {
    let rect = element.getBoundingClientRect();
    return {
        x: clientX - rect.left,
        y: clientY - rect.top
    };
};

function scrollToTop() {
    window.scrollTo(0, 0);
}
