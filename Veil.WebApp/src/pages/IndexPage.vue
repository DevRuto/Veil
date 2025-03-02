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
import { onMounted, ref } from 'vue'
import type { Message } from 'components/models'
import VeilMessage from 'components/VeilMessage.vue'
import { getMessages } from 'src/services/api/messages'

const messages = ref<Message[]>()

onMounted(async () => {
  messages.value = await getMessages()
})
</script>
