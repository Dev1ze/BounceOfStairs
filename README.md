# C# Unity GameDev

<div align="center">
    <img src="https://github.com/Dev1ze/BounceOfStairs/assets/51072932/b9d0c8d8-478f-405d-ac5e-c9390ac38bf2" 
    align="center" style="width: 70%" />
</div>  

## Описание
Приветствую вас в проекте **"Bounce Of Stairs"**! Меня вдохновила игра **"Bumble UP"**, и я решил попробовать свои силы в создании подобной игры. Мой проект похож на оригинал, но я добавляю в него свои идеи и стили. 
>Я не создаю эту игру с целью заработка, а скорее для того, чтобы улучшить свои навыки, не только в разработке игр, но и в целом .NET-разработке, включая ООП, паттерны и т.д.

Этот проект - результат моего увлечения и желания развиваться в этой области. Благодарю за интерес к моей работе!
<div align="center">
    <img src="https://github.com/Dev1ze/BounceOfStairs/assets/51072932/ad46927e-f6f4-4708-8eb6-444328994d5a"/>
</div>

## Движение по кривой Безье
### Определение
>**Кривая Безье** — это математически описанная кривая, используемая в компьютерной графике и анимации. Используются для создания плавных кривых, которые можно бесконечно сильно масштабировать.
<div align="center">
    <img src="https://github.com/Dev1ze/BounceOfStairs/assets/51072932/d49760b2-afdf-41a8-868f-94b422773d29"
    style="width: 100%"/>
</div>

Кривая описывается массивом контрольных точек **P0**, **P1**, **P2** и **P3**. Чтобы нарисовать кривую, необходимо нарисовать две линии, одна из которых будет иметь координаты **P0** и **P1**, а другая — **P1** и **P2**. Затем крайние точки этих линий начинают непрерывно двигаться к следующим точкам. Третья воображаемая линия рисуется с начальной точкой, непрерывно двигающейся по первой линии, и конечной точкой, двигающейся по второй линии. На этой линии рисуется точка, движущаяся от начала линии до самого конца.

<div align="center">
    <img src="https://github.com/Dev1ze/BounceOfStairs/assets/51072932/929df1f9-5637-4782-ba73-666b65ab3fb0"/>
</div>

### Реализация

Я создал отдельный класс `Bezier` в котором будет все что необходимо для реализации плавного движения. Принцип работы кривой Безье основан на комбинации нескольких контрольных точек, обычно четырех: начальной точки **P0**, двух промежуточных точек **P1** и **P2** и конечной точки **P3**. Кривая Безье строится путем интерполяции между этими точками.

В методе `StartMoving` класса `Bezier` происходит вычисление положения точки на кривой Безье в зависимости от параметра `progress`, который изменяется от `0` до `1`, представляя собой прогресс движения от начальной точки **P0** до конечной точки **P3**. Для вычисления позиции используется метод интерполяции `Lerp`, который позволяет плавно перемещаться между точками.

Использование отдельного класса `Bezier`, отвечающего только за вычисление позиции на кривой Безье, соответствует **S.O.L.I.D**, *принципу единственной ответственности (Single Responsibility Principle)*. Это позволяет разделить ответственность между классами и методами.

```C#
public static class Bezier
{
    public static Vector3 StartMoving(Vector3 P0, Vector3 P1, Vector3 P2, Vector3 P3, float progress)
    {
        Vector3 P01 = Vector3.Lerp(P0, P1, progress);
        Vector3 P12 = Vector3.Lerp(P1, P2, progress);
        Vector3 P23 = Vector3.Lerp(P2, P3, progress);

        Vector3 P012 = Vector3.Lerp(P01, P12, progress);
        Vector3 P123 = Vector3.Lerp(P12, P23, progress);

        Vector3 P0123 = Vector3.Lerp(P012, P123, progress);
        return P0123;
    }
}
```

Применяется метод `StartMoving` в скрипте движения как для *Player* так и *Enemy*, непосредственно в корутине, часть кода, которая обновляется каждый кадр благодаря `yield return null`

```C#
    public IEnumerator Movement()
    {
        while(movementQueue.Count > 0)
        {
            progress = 0;
            Vector3 P0 = new Vector3();
            Vector3 P1 = new Vector3();
            Vector3 P2 = new Vector3();
            Vector3 P3 = new Vector3(); //4 точки для кривой Бизье

            movementQueue[0].GetMovementPoints(Player, ref P0, ref P1, ref P2, ref P3);

            while (progress <= 1)
            {
                progress += Time.deltaTime * 6f;
                transform.position = Bezier.StartMoving(P0, P1, P2, P3, progress); //Кривая Бизье
                yield return null;
            }
            movementQueue.RemoveAt(0);
        }
        isJumping = false;
    }
```

## Бесконечная генерация мира

Для имитации бесконечного мира была разработана система чанков, представляющих участки лестницы. Каждый чанк состоит из двух точек - начала и конца, определенных компонентами `Transform` с именами `Began` и `End` соответственно.

При приближении игрока к концу текущего чанка автоматически создается новый чанк, начиная с конечной точки предыдущего. Это обеспечивает скрипт `ChankPlacer`, где проверяется позиция игрока. Если он превышает конечную позицию текущего чанка, вызывается метод `SpawnChank()`.

Для предотвращения переполнения памяти чанки, находящиеся за пределами видимости игрока, удаляются. Это осуществляется через список `SpawnedChanks`, который хранит все созданные чанки. Если количество чанков превышает определенный порог (в данном случае 3), самый старый чанк удаляется методом `DeleteChank()`.

Таким образом, система чанков позволяет создавать и удалять чанки по мере необходимости, создавая впечатление бесконечного мира и эффективно управляя ресурсами.
`
<div align="center">
    <img src="https://github.com/Dev1ze/BounceOfStairs/assets/51072932/705c168b-03fa-4c90-aee4-26fba95a893c"/>
</div>


```C#
public class Chank : MonoBehaviour
{
    [SerializeField] public Transform Began;
    [SerializeField] public Transform End;
    ...
```

```C#
public class ChankPlacer : MonoBehaviour
{
    [SerializeField] Transform Player;
    public List<GameObject> SpawnedChanks;
    [SerializeField] public GameObject FirstChank;
    [SerializeField] public GameObject ChankPrefab;
    int i;

    void Start()
    {
        SpawnedChanks.Add(FirstChank);
    }

    void Update()
    {
        if (Player != null) 
        {
            if (Player.position.z > SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().Began.transform.position.z)
            {
                SpawnChank();
                DeleteChank();
            }
        }   
    }

    void DeleteChank()
    {
        if (SpawnedChanks.Count > 3)
        {
            Destroy(SpawnedChanks[0].gameObject);
            SpawnedChanks.RemoveAt(0);
        }
    }

    void SpawnChank()
    {
        GameObject newChank = Instantiate(ChankPrefab);
        newChank.transform.position = SpawnedChanks[SpawnedChanks.Count - 1].GetComponent<Chank>().End.position - newChank.GetComponent<Chank>().Began.transform.localPosition;
        SpawnedChanks.Add(newChank);
        i = 0;
    }
}   
```

##  Социальные сети
<div align="center">
<a href="https://github.com/Dev1ze" target="_blank">
<img src=https://raw.githubusercontent.com/danielcranney/readme-generator/main/public/icons/socials/github.svg alt=github style="margin-bottom: 5px;" width="32"/>
</a>
<a href="https://www.youtube.com/@_devize_" target="_blank">
<img src=https://github.com/Dev1ze/BounceOfStairs/assets/51072932/55f6ea26-a1a2-48e7-b816-bbad461837f8 alt=youtube style="margin-bottom: 5px;" width="32"/>
</a>  
<a href="https://vk.com/artemander" target="_blank">
<img src=https://github.com/Dev1ze/BounceOfStairs/assets/51072932/1685225c-a2e2-42a7-98ec-288161bf8bc9 alt=youtube style="margin-bottom: 5px;" width="32"/>
</a>  
</div>  
  

