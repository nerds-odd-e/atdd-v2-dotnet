# language: zh-CN
@api-login
功能: redis

  场景: 读redis
    当向缓存"redis"写入:
    """
    {
      "message": "hello"
    }
    """
    当GET "/redis"
    那么response should be:
    """
    body.json.message= hello
    """

  场景: 写redis
    当POST "/redis":
    """
    {
      "message": "world"
    }
    """
    那么response should be:
    """
    code=200
    """
    那么缓存"redis"应为:
    """
    json.message= world
    """
