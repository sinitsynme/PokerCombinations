# PokerCombinations [RUS]

A C# console application which counts all iterations of combinations of Tehas Holdem cards and their probability.

Консольное приложение на C#, подсчитывающее все возможные комбинации Техасского Холдема и их вероятности.
_______________

The idea used in the application is to map Poker cards to integers from 1 to 52 bijectively. Obviously, an iteration of numbers is completed faster than an iteration of objects and its fiels.
Combinations are determined definitely by an array of 5 integers using fast methods of determination of suit and value by a number of a card (1-52).
Backtracking idea is used for iterating through the array.

Идея, использованная в приложении, основана на возможности построения биективного отображения (взаимно-однозначной функции) между игральными картами и числами от 1 до 52.
Очевидно, что перебор чисел осуществляется гораздо быстрее, нежели перебор объектов и их полей. Комбинации определяются однозначно массивом из 5 чисел, при этом используются быстрые методы определения
масти и достоинства карты по числу (1-52).
Для перебора массива используется идея бэктрэкинга.
_______________


Ссылка на тезис в РИНЦ (Link to the article):  http://repo.ssau.ru/bitstream/Mezhdunarodnaya-molodezhnaya-nauchnaya-konferenciya-Korolevskie-chteniya/Perebor-sochetanii-iz-kolody-igralnyh-kart-93170/1/978-5-7883-1668-0_2021-412-413.pdf

