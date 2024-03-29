﻿# **Tank Battleground**

#### **Проект по предметот „Визуелно Програмирање“**

# 
# 
# 
### Опис на играта
# 
Tank Battleground претставува multiplayer игра напишана во програмскиот јазик  **C#** и е првично инспирирана од оригиналната [Tank Trouble](http://www.tanktrouble.com/). Два непријателски тенкови се бараат низ мапата и кој прв ќе го уништи противникот добива поен. Победник е оној кој прв освоил 3 поени.


### Интерфејс, функционалности и правила

![alt tag](http://i62.tinypic.com/m7xq0z.png)
*На сликата е претставен почетниот мени интерфејс на Tank Battleground.*

###### Со кликање на:
> - **New game** - *се започнува нова игра*
> - **How to play** - *се отвара нов прозор упатство за контролите на играта*
> - **About** - *се отвара MessageBox со информација за играта*
> - **Quit**-  *ја исклучува играта*

# 
Кога ќе се пушти нова игра се прикажува следната содржина на прозорецот
![alt tag](http://i58.tinypic.com/25g9icy.png)

#####Синиот тенк се контролира со:
>-	**W**- се движи нагоре
>-	**S**- се движи надолу
>-	**A**-  се движи лево
>-	**D**- се движи десно
>-	**Tab**- пука

#####Црвениот тенк се контролира со:
>-	**Стрелка нагоре** - се движи нагоре
>-	**Стрелка надолу** - се движи надолу
>-	**Стрелка лево** - се движи лево
>-	**Стрелка десно** - се движи десно
>-	**Space**- пука

![alt tag](http://i59.tinypic.com/2m44sc5.jpg)

Кога било кој тенк ќе го уништи противничкиот тенк , добива поен и одново се поставува играта. Кога било кој тенк ке стигне до 3 поени се декларира како победник и програмата се враќа  на почетниот прозор од каде повторно може да се избери нова игра.
![alt tag](http://i62.tinypic.com/25r2i60.png)

### Програмско решение на проблемот
За реализација на проектот креирани се три кориснички дефинирани класи `Scene`, `Tank` и `Bullet`.

Во `Scene` класата се генерира почетната сцена на играта и се инцијализираат сите променливи и објекти од класите `Tank` и `Bullet` за работа на играта. За полето се користи еден квадрат (Rectangle) а за дефинирање на ѕидовите се користи матрица од квадрати (класата `Rectangle` ) која има ширина и должина колку квадратот на полето и  матрица од bool со исти димензии  . Димензиите за полето и блоковите на зидовите се чуваат како static readonly. За да може да се реализира движење на двата тенка во исто време се чува и листа на притиснати копчиња. Исто така се чува и бројот на поените за секој тенк посебно. Во класата се чуваат и методите на сите контроли и цртањето објектите кои соодветно се повикуваат во соодветниот event handler метода во класата на формата.

Во `Tank` класата се поставуваат параметрите на тенкот (слика, димензии, позиција, насока, листа од класата `Bullet` и објект од противничкиот тенк). Исто така дефинирани се повеќе методи кои го контролираат движењето и проверуваат во која насока може да се движе и дали има ѕидови, како и метод за пукање со кој се доава нов куршум во листата и метод за уништување на тенкот. Се чува и тајмер за траење на експлозијата. 

Во `Bullet` класата се чуваат праметри за куршумот (слика, димензии, позиција, насока), метод за цртање, и методи за координирање на движењето.

Во класата на формата се чува метод `load()` во кој се иницијализира формата и се иницијализира објект од класата `Scene` како и тајмер кој се стартува со самото пуштање на играта кој повикува метода од класата `Scene` во која се повикани методите за движење на тенковите и куршумите. Во програмата се додадени и звуци за подобро UX.

### Опис на алгоритмот за пукање на куршум

Кога ќе се притисне Space или Tab во однос на насоката на тенкот се додава нов објект во листата на куршуми на тенкот. Со методот за цртање на тенкот се исцртува и неговата листа на куршуми, тој метод се повикува во `Paint` настанот на формата. 

Во класата на тенкот се чува метод `Fire` во кој за секој куршум во листата на куршуми се повикува методoт `Мove` за движење на куршумот. Методот  `Fire` се повикува во методот `timerTick` во `Scene` класата кој се повикува на секој интервал на главниот тајмер на играта кој се чува во формата. Со тоа тајмерот постојано го повикува методот `Fire` кој проверува дали има куршуми во листата,  кои ги придвижува. Ако куршумот дојде до некој ѕид или уништи друг тенк се брише од листата што веќе не постои и не може да се исцрта.

### Изработиле:

>- **Александар Богданоски, број на индекс: 132021**
>- **Александар Велјанов, број на индекс: 131088**
>- **Игнатиј Гичевски, број на индекс: 131004**



