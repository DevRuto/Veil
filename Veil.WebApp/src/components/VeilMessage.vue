<template>
  <q-card class="q-my-md">
    <q-card-section>{{ from }}</q-card-section>
    <q-card-section>{{ text }}</q-card-section>
  </q-card>
</template>

<script setup lang="ts">
import type { Message } from './models'

defineProps<Message>()
</script>
