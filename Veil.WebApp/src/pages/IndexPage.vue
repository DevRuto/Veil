<template>
  <q-page padding class="items-center justify-evenly">
    <veil-message
      v-for="message of messages"
      :key="message.id"
      :id="message.id"
      :from="message.from"
      :text="message.text"
    ></veil-message>
  </q-page>
</template>

<script setup lang="ts">
import { ref } from 'vue'
import type { Message } from 'components/models'
import VeilMessage from 'components/VeilMessage.vue'

const messages = ref<Message[]>([
  {
    id: 1,
    from: 'Ruto',
    text: 'hello there',
  },
  {
    id: 2,
    from: 'Ruto',
    text: 'test message',
  },
  {
    id: 3,
    from: 'Dog',
    text: 'Woof',
  },
  {
    id: 4,
    from: 'Cat',
    text: 'Meow',
  },
])
</script>
