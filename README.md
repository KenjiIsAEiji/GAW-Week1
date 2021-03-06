# GAW-Week1
5/11から5/17のGAW用リポジトリ

![image](https://user-images.githubusercontent.com/41467408/82152397-d9398600-989b-11ea-9379-4df8661dfca9.png)

#### ゲームのテーマは 『ヨット』
アイディアのきっかけは大学のヨット乗船の経験から
 
 ヨットは風向きをうまく利用することで、漕がずとも進み続けることができ、その動きは数学の内積を応用できそうと考えたため、作ってみようかと。

#### 操作方法に関して
AキーとDキーで左右に舵を切ることができ、Shiftキーを押しながらだと、より素早く舵を切ることができます。ただ、前進していないと方向を変えることはできません。
wキーで前方向に漕ぐことができる。進む力は少ないです。
オレンジ色の小さな旗は風が吹いている方向を表しており、旗が向いている方向と逆に船を向いていると、風の力だけでは進みません。最低でも、風が向かっている方向から外側に45度以上船を向けると風を受け前進することができる。追い風を受けると最大速力で進むことができる。

タイトル画面でspaceキーでスタート、ステージ上のチェックポイントを通過して、すべてのチェックポイントを通過したら、航海時間が表示されて、spaceキーでタイトルに戻る。

開発がギリギリになってしまったので、うまく動作しない可能性があります。

### 制作1日目（2020年5月11日）制作時間 4時間
 主に作るゲームのアイディア出しとざっくりとした設計。ゲームの目的や、ステージの見た目、今回はヨットを操作し世界観を見るようなゲームなので、ビジュアルは勿論のこと、ヨットの動きをなるべく再現できるようにプログラムしたいと考えてメモ( ..)φ

Unity2019.3.10f1のバージョンでURPテンプレを適用してセットアップ。また、InputSystemなど各種assetもパッケージから導入したところで今日は終了。

 <img src="https://user-images.githubusercontent.com/41467408/81573680-c593a880-93df-11ea-91d6-69acc1500a3d.JPG" width="320px">

### 制作2日目（2020年5月12日）制作時間 2時間
 UnityのProBuilderを使用して、ヨットのボート部分をモデリング。久しぶりのモデリングにもかかわらず、想像以上の出来に驚きながらも、コライダーをつけるのに四苦八苦。メッシュコライダーがうまくつけられなかったので、カプセルコライダーをつけることに決めた。
 
 昨日よりも授業時間は短かったものの、思った以上に大学のガイダンスや手続きに時間がかかり、作業時間が多く取れず。その結果プログラムも、InputManagerを適用してボートを動かす準備をして、今日は終了。
（ちなみに、ブランチを切り忘れているミス）

 <img src="https://user-images.githubusercontent.com/41467408/81701644-47013e80-94a5-11ea-8f6d-4feb0a3c1aa2.jpg" width="640px">

### 制作3日目（2020年5月13日）制作時間 6時間
 rigidbodyで大まかな動きのプログラミング。船の舵と前方に進む力を仮で作成。本来の動きにリンクさせるため、風を用意するのは、あすに行う予定。その間に帆の部分を機能と同じくProBuilderを使ってモデリング。マスト（帆を張る棒のようなもの？）は後々動かしやすいようにしたとともに、帆の部分にはClothシミュレーションを適用して、動きに合わせて揺れ動くようにした。
 

動いている動画等はこちら↓


https://twitter.com/kenjiDeOk/status/1260574493317173254?s=20

### 制作4日目（2020年5月14日）制作時間 5時間
 風向きを示すオブジェクトを設定して、風向きによって前進する速度が変わるように変更。ヨットは向かい風でも、風が向かってくる方向から45度外側に船を向けていれば、帆が飛行機の羽の役割をして前進することが可能なため、それを再現するように計算して船に力を加えています。
 
 風向きと船の方向との関係によって力を変える方法には、内積を使っています。「内積って何なのか？」という問いに答える際によく、「aベクトルとbベクトルの内積は『b→が，a→の方向に，a→と共に行った仕事の量である』」と説明されるわけですが、船が向いている方向と風向きの内積を取ることで、船が向いている方向に風がどれほど効率よく仕事ができているかを計算できるわけです。（図解するのが面倒だったので、参考にしたサイトを http://naop.jp/topics/topics14.html ）

ただ、現状45度より内側になった途端、急に動きが遅くなる感じであるため、ちょっとそこは改良するつもりです。

動いている動画等はこちら↓
https://twitter.com/kenjiDeOk/status/1260941442349850624?s=20

### 制作5日目（2020年5月15日）制作時間 5時間
 風向きと船の向きに応じて、帆の向きを自動的に動かすようにプログラミング。あと、ステージに関して波のように動くような水面シェーダをシェーダーグラフを使って実装。しかしながら、やはり見た目がイマイチ。シェーダは明日以降も改良していく予定です。プログラマーとしてやってきていて、こうしたビジュアル重視のゲームはかなり難しい...
 
https://twitter.com/kenjiDeOk/status/1261310353549299712?s=20

### 制作6日目（2020年5月15日）制作時間 10時間
 主に、ステージを完成させるために、海面をシェーダーグラフを使ってシェーダーを作成。しかしながら、波を打たせるように見せるためにいろいろ調べて作成するも、イマイチな見た目で、その上シェーダー作成に関しては初心者であるため、大きく時間をロス。本来であれば、ほかのステージ上に置くオブジェクトをつけ、乗組員をつけるところまで作成するつもりでいたが、時間がかかりすぎたため、今日は断念。あすは早い段階から作成する計画を十分にとってから、巻き返しを図りたいと思います。

<img src="https://user-images.githubusercontent.com/41467408/82122886-3583a380-97d1-11ea-92f3-e83653d7dd47.png" width="640px">
