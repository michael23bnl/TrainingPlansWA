
/*========================Event Listeners========================*/

function eventListeners() {
	const plan_area = document.querySelector('.card_section');
	if (plan_area) {
		plan_area.addEventListener('click', resultsDelegation);
	}
}
function resultsDelegation(e) {

	e.preventDefault();

	if (e.target.classList.contains('catalog_button_hands')) {
		window.location.href = "/HandsPlans";
	}

	if (e.target.classList.contains('catalog_button_legs')) {
		window.location.href = "/LegsPlans";
	}

	if (e.target.classList.contains('catalog_button_circuit')) {
		window.location.href = "/CircuitPlans";
	}

	if (e.target.classList.contains('create_plan_button')) {
		window.location.href = "/PlanCreate";
	}

	if (e.target.classList.contains('save_to_favorites')) {
		//console.log("trying to add to a list");
		const planId = e.target.dataset.id;
		//console.log(planId);
		fetch('/Favorites/AddToFavorite', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: planId,
		})
		.then(response => {
			//console.log("Response status:", response.status);	
			return response.json();
		})
		.then(data => {	
			//console.log("Response data:", data);							
			if (data.success == true) {
				//console.log("authenticated user, added to list");
				if (e.target.classList.contains('is-favorite')) {
					e.target.classList.remove('is-favorite');
					e.target.classList.remove('bxs-star');
					e.target.classList.add('bx-star');
					e.target.title = 'Добавить в избранное';
				}
				else {
					e.target.classList.add('is-favorite');
					e.target.classList.remove('bx-star');
					e.target.classList.add('bxs-star');
					e.target.title = 'Удалить из избранного';
				}
			}
			else {
				//console.log("unauthenticated user");				
			}
		})
			.catch(error => {
				//console.error('Ошибка при обработке запроса:', error)
				//console.log(window.location.href);
				var current_page_link = window.location.href;
				if (current_page_link.includes("/HandsPlans")) {			
					window.location.href = "/Identity/Account/Login?ReturnUrl=%2FHandsPlans";
				}
				if (current_page_link.includes("/LegsPlans")) {
					window.location.href = "/Identity/Account/Login?ReturnUrl=%2FLegsPlans";
				}
				if (current_page_link.includes("/CircuitPlans")) {
					window.location.href = "/Identity/Account/Login?ReturnUrl=%2FCircuitPlans";
				}
			});	
	}

	if (e.target.classList.contains('remove_from_favorites')) {
		//console.log("trying to remove from a list");
		const planId = e.target.dataset.id;
		//console.log(planId);		
		fetch('/Favorites/RemoveFromFavorite', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: planId,
		})
			.then(response => {
				if (response.ok) {
					//console.log("removed from list");
					//удаляем карточку с планом со страницы избранного
					e.target.parentElement.parentElement.remove();
					//проверяем, остались ли планы на странице избранного
					if (document.querySelector('.card') == null) { //если нет - перезагружаем старницу для вывода сообщения, что в избранном пусто
						//location.reload(true);
					}

				} else {

					//console.log("failed while removing from list");
				}
			})
			.catch(error => console.error('Ошибка при обработке запроса:', error));
	}

	if (e.target.classList.contains('remove_from_creations')) {
		//console.log("trying to remove from a list");
		const planId = e.target.dataset.id;
		//console.log(planId);		
		fetch('/CreatedPlans/RemoveFromCreations', {
			method: 'POST',
			headers: {
				'Content-Type': 'application/json',
			},
			body: planId,
		})
			.then(response => {
				if (response.ok) {
					//console.log("removed from list");

					//удаляем карточку с планом со страницы избранного
					e.target.parentElement.parentElement.remove();
					//проверяем, остались ли планы на странице созданных планов
					if (document.querySelector('.card') == null) { //если нет - перезагружаем старницу для вывода сообщения, что страница созданных планов пустая
						//location.reload(true);
					}

				} else {

					//console.log("failed while removing from list");
				}
			})
			.catch(error => console.error('Ошибка при обработке запроса:', error));
	}

	if (e.target.classList.contains('edit_creation')) {
		//console.log("trying to edit a plan");
		const planId = e.target.dataset.id;
		//var planId = e.target.dataset.id.serialize();
		//console.log(planId);
		$.ajax({
			type: 'POST',
			url: '/CreatedPlans/Edit', 
			contentType: 'application/json', // Set content type to JSON
			data: JSON.stringify({ createdPlanId: parseInt(planId) }),
			success: function (response) {
				//location.reload(true);
				const plan = e.target.parentElement.parentElement.parentElement;

				$(plan).html(response);
				// Обработка успешного ответа от сервера
				//console.log(response);
			},
			error: function (error) {
				// Обработка ошибки
				console.error('Ошибка при отправке AJAX-запроса:', error);
			}
		});
	}

	if (e.target.classList.contains('submit_input_type')) {
		//console.log("submit button here");
		//идентифицируем форму 
		const form = e.target.parentElement.parentElement.parentElement;
		//собираем данные с формы
		var formData = $(form).serialize();
		if (!validateForm()) { //без этой проверки всё будет работать, но тогда
			//при редактировании можно будет сохранять планы с незаполненными полями
			// Прерываем отправку формы, если валидация не прошла
			return false;
		}
		//AJAX-запрос
		$.ajax({
			type: 'POST',
			url: '/CreatedPlans/SaveEditedPlan', 
			data: formData,
			success: function (response) {
				const form1 = form.parentElement.parentElement.parentElement;
				$(form1).html(response);
				// Обработка успешного ответа от сервера
				//console.log(response);
			},
			error: function (error) {
				// Обработка ошибки
				console.error('Ошибка при отправке AJAX-запроса:', error);
			}
		});		
	}	
}

eventListeners();