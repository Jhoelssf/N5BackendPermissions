# N5BackendPermissions
## Net 7.0 project

- Instructions to run project
- Go to N5Api folder
- In the root of N5Api run this command

```cmd
docker-compose up -d
```
- If elasticsearch turn off automally, maybe the reason is memory
```cmd
wsl -d docker-desktop sysctl -w vm.max_map_count=262144
```

- If the N5Api turns off, wait to sql turn on next turn on N5Api again
