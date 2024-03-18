
/*========================User Interface========================*/

/*регистрация скроллтриггера и скроллсмусера*/
gsap.registerPlugin(ScrollTrigger, ScrollSmoother);

if (ScrollTrigger.isTouch !== 1) {

	/*ScrollSmoother.create({
		wrapper: '.wrapper',
		content: '.content',
		smooth: 2,               // how long (in seconds) it takes to "catch up" to the native scroll position
		effects: true,           // looks for data-speed and data-lag attributes on elements
		smoothTouch: 0.1,        // much shorter smoothing time on touch devices (default is NO smoothing on touch devices)
	});*/

	gsap.fromTo('.plan_examples', { opacity: 0 }, {
		opacity: 1,
		ScrollTrigger: {
			trigger: '.plan_examples',
			start: 'center',
			end: 'bottom',
			scrub: true,
		}
	});

	/*===================Анимация для примеров планов слева===================*/

	let itemsLeft = gsap.utils.toArray('.gallery__left .gallery__item')

	itemsLeft.forEach(item => {
		gsap.fromTo(item, { x: -150, y: 100, opacity: 0 }, {
			opacity: 1, x: 0, y: 0,
			scrollTrigger: {
				trigger: item,
				/*start: 'top bottom',
				end: 'center center',*/
				start: '-1000',
				end: '-415',
				scrub: true,
				/*markers: true,*/
			}
		});
	});

	/*===================Анимация для примеров планов справа===================*/

	let itemsRight = gsap.utils.toArray('.gallery__right .gallery__item')

	itemsRight.forEach(item => {
		gsap.fromTo(item, { y: 100, opacity: 0 }, {
			opacity: 1, x: 0, y: 0,
			scrollTrigger: {
				trigger: item,
				start: '-850',
				end: '-415',
				scrub: true,
			}
		});
	});

	const observer = new IntersectionObserver((enteries) => {
		enteries.forEach((entry) => {
			/*console.log(entry);*/
			if (entry.isIntersecting) {
				entry.target.classList.add('show');
			}
			else {
				entry.target.classList.remove('show');
			}
		});
	});

	const hiddenElements = document.querySelectorAll('.hidden');
	hiddenElements.forEach((el) => observer.observe(el));

}
