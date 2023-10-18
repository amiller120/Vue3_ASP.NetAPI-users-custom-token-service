<script setup lang="ts">
  import { onMounted, ref } from "vue";

  interface TestData {
    test: string;
  }

  const result = ref<TestData>({ test: "" })
  onMounted(async () => {
    result.value = await (await fetch("/api/test")).json();
  });

</script>

<template>
  <div>Result: {{ result.test }}</div>
</template>
