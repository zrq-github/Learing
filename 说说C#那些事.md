# 说说C#那些事

随便记录一些关于C#的知识点.

## 关于Using

using是try-finally的语法糖. 这是在看书发现的一段用例

```C#
// foreach 的Reflector反编译
List＜object＞list=new List＜object＞();
using(List＜object＞.Enumerator CS$5$0000=list.GetEnumerator())
{
while(CS$5$0000.MoveNext())
{
object current=CS$5$0000.Current;
}
}
// 等价
List＜object＞.Enumerator CS$5$0000=list.GetEnumerator();
try
{
//循环
}
finally
{
CS$5$0000.Dispose();
}
```

## 关于垃圾回收

这个垃圾回收是在一本书上的参考用例上看见, 参照一下

```C#
GC.Collect();//强制对所有代码进行即时垃圾回收
GC.WaitForPendingFinalizers();//挂起线程，执行终
//结器队列中的终结器（即析构方法）
GC.Collect();//再次对所有代码进行垃圾回收，主要包括
//从终结器队列中出来的对象
collectionCount=GC.CollectionCount(0);//返回
//在0代中执行的垃圾回收次数
watch=new Stopwatch();
watch.Start();
```
