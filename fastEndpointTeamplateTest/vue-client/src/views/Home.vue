<template>
  <div>
    <h1>{{ state.response }}</h1>
  </div>
</template>

<script lang="ts" setup>
  import TestService from '../Services/Api/TestService'
  import { onMounted, ref, reactive } from 'vue'

  const state = reactive({
    response: ''
  })

  onMounted(async () => {
    let response = await TestService.GetTest<string>()
    debugger;
    state.response = response.data;
  })

</script>
