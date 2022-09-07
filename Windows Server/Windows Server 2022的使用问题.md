# Windwos server 使用问题

- Windwos server 2022 ping不通
ping不通：不一定是Vmware设置问题，可能是Windows Server本身关闭了ping
进入：控制面板->管理工具->找到 “高级安全Windows防火墙”；
点击：入站规则；
找到：回显请求-ICMPv4-In （Echo Request – ICMPv4-In）；
右键：点击规则 点击“启用规则（Enable）。
- 啊
