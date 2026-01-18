# BasicUIProject

BasicUIProject は .NET を使ったシンプルな UI テンプレートです。
最新の .NET 機能を利用して、素早くデスクトップ UI アプリケーション（WPF）を立ち上げるための最小限の構成とサンプルを提供します。

## 概要
このリポジトリは、WPF を用いた基本的なユーザーインターフェイスの構造、データバインディング、値変換器（ValueConverter）などのサンプルを含みます。
学習目的やプロジェクトの雛形としてそのまま利用できます。

## 主な特徴
- `MainWindow.xaml` による基本的なウィンドウ構成（ボタン、テキスト、バインディング例）
- `MainWindow.xaml.cs` によるコードビハインドのサンプル
- 値変換器のサンプル：`Converter/MinValueConverter.cs`
- 最小限のプロジェクト構成で .NET 10 環境向けに最適化

## システム要件
- .NET 10 SDK / ランタイム
- Windows（WPF が対象のため）
- 推奨開発環境：Visual Studio 2026（または `dotnet` CLI）

## セットアップと実行方法

Visual Studio を使う場合
1. リポジトリをクローンまたはダウンロードします。
2. Visual Studio 2026 でソリューションを開きます。
3. ターゲットフレームワークが `.NET 10` になっていることを確認します（`Target Framework`）。
4. `F5` もしくは __Debug > Start Debugging__ で実行します。

CLI（`dotnet`）を使う場合
1. リポジトリのルートで以下を実行：
   - `dotnet restore`
   - `dotnet build`
   - `dotnet run --project <プロジェクトファイル名>`（必要に応じてプロジェクトパスを指定）

## プロジェクト構成（主なファイル）
- `App.xaml` / `App.xaml.cs` — アプリケーションエントリポイントとリソース定義
- `MainWindow.xaml` / `MainWindow.xaml.cs` — メイン UI とそのコードビハインド
- `Converter/MinValueConverter.cs` — 値変換器のサンプル（バインディングに利用）
- `AssemblyInfo.cs` — アセンブリ情報
- `README.md` — 本ドキュメント

これらファイルは学習用の最低限の要素に絞ってあります。必要に応じて `Views`、`ViewModels`、`Models` フォルダを追加してください。

## カスタマイズのヒント
- デザインを分離するなら `Resources` フォルダに `ResourceDictionary` を置き、`App.xaml` で参照します。
- 複雑なロジックは MVVM パターンに沿って `ViewModel` に移行してください。
- 追加のコンバータは `Converter` フォルダを拡張して実装します（例：`IValueConverter` を実装）。

## テスト
このテンプレートはユニットテストプロジェクトを含みません。必要に応じて `xUnit` や `NUnit` を導入し、`ViewModel` やロジック層のテストを追加してください。

## 貢献
1. Issue を開いて提案やバグを報告してください。
2. フォークしてブランチを作成し、変更をコミットしてください。
3. プルリクエストを送ってください。変更点は簡潔に説明してください。

## ライセンス
リポジトリにライセンスファイルが無い場合は、利用前にライセンスを明記してください。一般的には `MIT` などのオープンソースライセンスが使われます。
