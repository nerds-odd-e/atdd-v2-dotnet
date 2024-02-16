# language: zh-CN
@api-login
功能: redis

#  场景: 读redis
#    当向缓存"foo"写入:
#    """
#    {
#      "message": "hello"
#    }
#    """
#    当GET "/redis"
#    那么response should be:
#    """
#    body.json.message= hello
#    """
