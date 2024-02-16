package com.odde.atddv2;

import com.github.leeonky.dal.extensions.jdbc.DataBaseBuilder;
import com.github.leeonky.jfactory.cucumber.JData;
import io.cucumber.java.Before;
import io.cucumber.java.zh_cn.假如;
import io.cucumber.java.zh_cn.当;
import io.cucumber.java.zh_cn.那么;
import lombok.SneakyThrows;
import lombok.extern.slf4j.Slf4j;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.data.redis.core.RedisTemplate;
import org.springframework.kafka.core.KafkaTemplate;

import javax.sql.DataSource;
import java.sql.Connection;

import static com.github.leeonky.dal.Assertions.expect;
import static org.awaitility.Awaitility.await;

@Slf4j
public class KafkaSteps {

    @Autowired
    private TestKafkaConsumer kafkaConsumer;

    @Autowired
    private KafkaTemplate<String, String> kafkaTemplate;

    @假如("清空队列{string}")
    public void 清空队列(String topic) {
        kafkaConsumer.clear(topic);
    }

    @那么("队列应为:")
    public void 队列应为(String expression) {
        expect(kafkaConsumer).should(expression);
    }

    @当("向队列{string}写入:")
    public void 向队列写入(String topic, String text) {
        kafkaTemplate.send(topic, text);
    }

    @Autowired
    DataSource dataSource;

    @SneakyThrows
    @那么("数据库应为:")
    public void 数据库应为(String expression) {
        DataBaseBuilder builder = new DataBaseBuilder();
        try (Connection connection = dataSource.getConnection()) {
            expect(builder.connect(connection)).should(expression);
        }
    }

    @Autowired
    JData jData;

    @那么("所有{string}最终应为:")
    public void 所有最终应为(String query, String expression) {
        await().untilAsserted(() -> jData.allShould(query, expression));
    }

    @Autowired
    private RedisTemplate<String, String> redisTemplate;

    @Before
    public void clearRedis() {
        redisTemplate.getConnectionFactory().getConnection().flushAll();
    }

    @当("向缓存{string}写入:")
    public void 向缓存写入(String key, String value) {
        redisTemplate.opsForValue().set(key, value);
    }

    @那么("缓存{string}应为:")
    public void 缓存应为(String key, String expression) {
        await().ignoreExceptions().untilAsserted(() -> expect(redisTemplate.opsForValue().get(key)).should(expression));
    }
}
